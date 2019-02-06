// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Rest.Azure;

    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.Sockets;

    /// <summary>
    ///     The Peering base cmdlet
    /// </summary>
    public class PeeringBaseCmdlet : AzureRMCmdlet
    {
        private IEdgeRpClient peeringClient;

        /// <summary>
        /// The PeeringClient
        /// </summary>
        public IEdgeRpClient EdgeClient
        {
            get
            {
                return this.peeringClient ?? (this.peeringClient =
                                                  AzureSession.Instance.ClientFactory.CreateArmClient<EdgeRpClient>(
                                                      this.DefaultProfile.DefaultContext,
                                                      AzureEnvironment.Endpoint.ResourceManager));
            }

            set
            {
                this.peeringClient = value;
            }
        }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///     The Peering carrier client.
        /// </summary>
        public IPeeringPartnersOperations PeeringServiceClient => this.EdgeClient.PeeringPartners;

        /// <summary>
        ///     The Peering client.
        /// </summary>
        public IPeeringsOperations PeeringClient => this.EdgeClient.Peerings;

        /// <summary>
        ///     The PSPeering location client.
        /// </summary>
        public IPeeringLocationsOperations PeeringLocationClient => this.EdgeClient.PeeringLocations;

        public IPeeringLegacyPeeringsOperations PeeringLegacyClient => this.EdgeClient.PeeringLegacyPeerings;

        /// <summary>
        ///     The Peering prefixes client.
        /// </summary>
        public IPeeringPrefixesOperations PeeringPrefixesClient => this.EdgeClient.PeeringPrefixes;

        /// <summary>
        ///     The prefixes client.
        /// </summary>
        public IPrefixesOperations PrefixesClient => this.EdgeClient.Prefixes;

        /// <summary>
        ///     The Peering subscriber client.
        /// </summary>
        public IPeeringSubscribersOperations PeeringSubscriberClient => this.EdgeClient.PeeringSubscribers;

        /// <summary>
        ///     The Peering peering client subscribers.
        /// </summary>
        public ISubscribersOperations PeeringSubscribersClient => this.EdgeClient.Subscribers;

        /// <summary>
        /// The to peering.
        /// </summary>
        /// <param name="resourceGroup">
        /// The resource group.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        public PSPeering ToPeering(string resourceGroup, string name)
        {
            var ic = this.PeeringClient.Get(resourceGroup, name);

            var psPeering = PeeringResourceManagerProfile.Mapper.Map<PSPeering>(ic);
            return psPeering;
        }

        /// <summary>
        /// The to peering.
        /// </summary>
        /// <param name="pSPeering">
        /// The p s peering.
        /// </param>
        /// <returns>
        /// The <see cref="PeeringModel"/>.
        /// </returns>
        public PeeringModel ToPeering(object pSPeering)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(pSPeering);
        }

        /// <summary>
        /// The to peering ps.
        /// </summary>
        /// <param name="peering">
        /// The peering.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object ToPeeringPs(object peering)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(peering);
        }

        /// <summary>
        /// The to peering subscriber ps.
        /// </summary>
        /// <param name="peering">
        /// The peering.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeeringSubscriber"/>.
        /// </returns>
        public PSPeeringSubscriber ToPeeringSubscriberPs(object peering)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeeringSubscriber>(peering);
        }

        /// <summary>
        /// The to ps peering partner.
        /// </summary>
        /// <param name="peering">
        /// The peering.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeeringPartner"/>.
        /// </returns>
        public PSPeeringPartner ToPSPeeringPartner(object peering)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeeringPartner>(peering);
        }

        /// <summary>
        /// The top s peering location.
        /// </summary>
        /// <param name="peering">
        /// The oc.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeeringLocation"/>.
        /// </returns>
        public PSPeeringLocation TopSPeeringLocation(object peering)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeeringLocation>(peering);
        }

        /// <summary>
        /// The validate bandwidth.
        /// </summary>
        /// <param name="toValidateBandwidth"></param>
        /// <param name="peeringVlanBandwidthInMbps">
        /// The Peering Vlan Bandwidth In Mbps.
        /// </param>
        /// <param name="defaultVlanBandwidthInMbps">
        /// The default Vlan Bandwidth In Mbps.
        /// </param>
        /// <param name="totalBandwidthInMbps">
        /// The bandwidth In Mbps.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Incorrect bandwidth.
        /// </exception>
        public int? ValidateVlanBandwidth(
            int? toValidateBandwidth,
            int? peeringVlanBandwidthInMbps,
            int? defaultVlanBandwidthInMbps,
            int? totalBandwidthInMbps)
        {
            var i = totalBandwidthInMbps ?? peeringVlanBandwidthInMbps + defaultVlanBandwidthInMbps;
            if (toValidateBandwidth % Constants.MinRange != 0)
                throw new Exception($"VlanBandwidth:{toValidateBandwidth} must be a divisible by {Constants.MinRange}");
            if (toValidateBandwidth % Constants.MinRange == 0 && this.CompareDefaultToPeeringVlan(
                    peeringVlanBandwidthInMbps ?? 0,
                    defaultVlanBandwidthInMbps ?? 0,
                    i)) return toValidateBandwidth;
            throw new Exception("VlanBandwidth provided is not supported.");
        }

        /// <summary>
        ///     The validate bandwidth.
        /// </summary>
        /// <param name="bandwidthInMbps">
        ///     The bandwidth in mbps.
        /// </param>
        /// <returns>
        ///     The validated bandwidth.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int? ValidateBandwidth(int? bandwidthInMbps)
        {
            if (bandwidthInMbps % Constants.MinRange == 0) return bandwidthInMbps;
            throw new Exception("VlanBandwidth provided is not supported.");
        }

        /// <summary>
        /// The compare default to Peering vlan.
        /// </summary>
        /// <param name="PeeringVlanBandwidthInMbps">
        /// The Peering vlan bandwidth in mbps.
        /// </param>
        /// <param name="defaultVlanBandwidthInMbps">
        /// The default vlan bandwidth in mbps.
        /// </param>
        /// <param name="bandwidthInMbps">
        /// The bandwidth In Mbps.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public bool CompareDefaultToPeeringVlan(
            int? PeeringVlanBandwidthInMbps,
            int? defaultVlanBandwidthInMbps,
            int? bandwidthInMbps)
        {
            if (PeeringVlanBandwidthInMbps + defaultVlanBandwidthInMbps == bandwidthInMbps) return true;
            throw new Exception(
                $"PeeringVlanBandwidthInMbps + DefaultVlanBandwidthInMbps({PeeringVlanBandwidthInMbps + defaultVlanBandwidthInMbps}) does not equal BandwidthInMbps ({bandwidthInMbps})");
        }

        /// <summary>
        /// The return newly created Peering.
        /// </summary>
        /// <param name="PeeringName">
        /// The Peering name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        public PSPeering ReturnNewlyCreatedPeering(string PeeringName, string resourceGroupName)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                this.PeeringClient.Get(resourceGroupName, PeeringName));
        }

        /// <summary>
        /// The get resource group name from id.
        /// </summary>
        /// <param name="PeeringId">
        /// The Peering id.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetResourceGroupNameFromId(string PeeringId)
        {
            var words = PeeringId.Split('/');
            bool isResourceGroup = false;
            foreach (var word in words)
            {
                if (!isResourceGroup)
                {
                    if (word.Equals("resourceGroups"))
                    {
                        isResourceGroup = true;
                    }
                }
                else
                {
                    return word;
                }
            }

            throw new ItemNotFoundException("No ResourceGroupName could be found for this object.");
        }

        public object GetPeeringNameFromId(string PeeringId)
        {
            var words = PeeringId.Split('/');
            bool isPeeringName = false;
            foreach (var word in words)
            {
                if (!isPeeringName)
                {
                    if (word.Equals("Peerings"))
                    {
                        isPeeringName = true;
                    }
                }
                else
                {
                    return word;
                }
            }

            throw new ItemNotFoundException("No ResourceGroupName could be found for this object.");
        }

        /// <summary>
        /// The validate prefix.
        /// </summary>
        /// <param name="routePrefix">
        /// The route prefix.
        /// </param>
        /// <param name="PeeringType">
        /// The Peering Type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ValidatePrefix(string routePrefix, string PeeringType)
        {
            if (routePrefix != null)
            {
                var prefix = RoutePrefix.GetValidPrefix(routePrefix);
                switch (prefix.PrefixAddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        if (PeeringType.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                        {
                            if (prefix.PrefixMaskWidth != 32)
                            {
                                throw new ArgumentOutOfRangeException($"Invalid Prefix: {routePrefix}, must be /32");
                            }
                        }
                        else
                        {
                            if (!(prefix.PrefixMaskWidth == 30 || prefix.PrefixMaskWidth == 31))
                            {
                                throw new ArgumentOutOfRangeException(
                                    $"Invalid Prefix: {routePrefix}, must be either /30 or /31");
                            }
                            else
                            {
                                var actualPrefixBigInt = prefix.ActualPrefixBigInt;
                                if (prefix.Length == 4)
                                {
                                    return prefix.StartOfPrefixBigInt + 2 == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"Your IP address: {routePrefix} must be at least {(prefix.StartOfPrefixBigInt + 2).ToIpAddress(AddressFamily.InterNetwork)} not greater than {(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetwork)}");
                                }
                                else if (prefix.Length == 2)
                                {
                                    return prefix.StartOfPrefixBigInt + 1 == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"IP address: {routePrefix} must be {(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetwork)} for the given IP Mask");
                                }

                                throw new ArgumentOutOfRangeException(
                                    $"IPv4 mask must be /30 or /31. IP Mask out of range {routePrefix}.");
                            }
                        }

                        return routePrefix;
                    case AddressFamily.InterNetworkV6:
                        if (PeeringType.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                        {
                            if (prefix.PrefixMaskWidth != 128)
                            {
                                throw new ArgumentOutOfRangeException($"Invalid Prefix: {routePrefix}, must be /128");
                            }
                        }
                        else
                        {
                            if (!(prefix.PrefixMaskWidth >= 64 && prefix.PrefixMaskWidth <= 127))
                            {
                                throw new ArgumentOutOfRangeException(
                                    $"IPv6 mask must be /64 - /127. IP Mask out of range {routePrefix}.");
                            }

                            switch (prefix.PrefixMaskWidth)
                            {
                                case 127:
                                    return prefix.StartOfPrefixBigInt + 1 == prefix.ActualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"IP address: {routePrefix} must be "
                                                     + $"{(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetworkV6)} "
                                                     + "for the given IP Mask");
                                default:
                                    return prefix.StartOfPrefixBigInt + 2 >= prefix.ActualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"Your IP address: {routePrefix} must be at least"
                                                     + $"{(prefix.StartOfPrefixBigInt + 2).ToIpAddress(AddressFamily.InterNetwork)} "
                                                     + $"not greater than {(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetwork)}");
                            }
                        }

                        return routePrefix;
                }

                throw new ArgumentOutOfRangeException($"Prefix out of range {routePrefix}.");
            }

            return null;
        }

        /// <summary>
        /// The base execute method.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Base Cmdlet execute.
        /// </summary>
        /// <exception cref="NetworkCloudException"></exception>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            try
            {
                Execute();
            }
            catch (CloudException ex)
            {
                throw new NetworkCloudException(ex);
            }
        }

        /// <summary>
        /// The get azure region.
        /// </summary>
        /// <param name="PeeringLocation">
        /// The Peering location.
        /// </param>
        /// <param name="kind">
        /// The kind.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public string GetAzureRegion(string PeeringLocation, string kind)
        {
            try
            {
                var icList = this.PeeringLocationClient.List(kind);
                foreach (var location in icList.Select(this.TopSPeeringLocation).ToList())
                {
                    if (location.Name == PeeringLocation)
                    {
                        return location.Name == "Building40" ? "centralus" : location.AzureRegion;
                    }
                }
            }
            catch
            {
                if (PeeringLocation.Equals("Building40", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "centralus";
                }
                throw new Exception("Unable to map AzureRegion to Peering location.");
            }
            throw new Exception("Unable to map AzureRegion to Peering location.");
        }
    }
}