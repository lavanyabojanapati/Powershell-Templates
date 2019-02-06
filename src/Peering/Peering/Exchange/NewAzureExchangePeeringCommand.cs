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
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    ///     New Azure Peering Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzExchangePeering",
        DefaultParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
    [OutputType(typeof(PSPeering))]
    public class NewAzureExchangePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy Peering.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering,
            DontShow = true)]
        public PSPeering LegacyPeering { get; set; }

        /// <summary>
        ///     Gets or sets The Peering NameMD5AuthenticationKeyHelp
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName =
                Constants.ParameterSetNameConvertLegacyPeering + Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }

        /// <summary>
        ///     Gets or sets The Resource Group Name
        /// </summary>
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName =
                Constants.ParameterSetNameConvertLegacyPeering + Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets The Peering Location.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the exchange session.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        public virtual List<PSExchangeConnection> ExchangeSession { get; set; }

        /// <summary>
        ///     Gets or sets The Peering Location.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual int? PeeringDBFacilityId { get; set; }

        /// <summary>
        ///     Gets or sets the MD5AuthenticationKey for the Peering.
        /// </summary>
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName =
                Constants.ParameterSetNameConvertLegacyPeering + Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        public string MD5AuthenticationKey { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised i pv 4.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName =
                Constants.ParameterSetNameConvertLegacyPeering + Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised i pv 6.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName =
                Constants.ParameterSetNameConvertLegacyPeering + Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        public virtual int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the session i pv 4 prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        public virtual string SessionIPv4Prefix { get; set; }

        /// <summary>
        /// Gets or sets the session i pv 6 prefix.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        public virtual string SessionIPv6Prefix { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.WriteObject(this.CreateExchangePeering());
        }

        /// <summary>
        /// The create Peering.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        private PSPeering CreateExchangePeering()
        {

            var PeeringRequest =
                new PSPeering(
                    name: this.PeeringName,
                    location: this.GetAzureRegion(this.PeeringLocation, Constants.Exchange))
                {
                    PeeringLocation = this.PeeringLocation,
                    Sku = new PSPeeringSku { Name = "basic_Exchange_Free" },
                    Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = new List<PSExchangeConnection>
                                                             {
                                                                 new PSExchangeConnection()
                                                                     {
                                                                         Session = new PSBgpSession{
                                                                             SessionPrefixV4 = this.ValidatePrefix(
                                                                                 this.SessionIPv4Prefix ?? null,
                                                                                 Constants.Exchange),
                                                                         SessionPrefixV6 = 
                                                                             this.ValidatePrefix(
                                                                                 this.SessionIPv6Prefix ?? null,
                                                                                 Constants.Exchange),
                                                                         MaxPrefixesAdvertisedV4 = 
                                                                             this.MaxPrefixesAdvertisedIPv4 ?? null,
                                                                         MaxPrefixesAdvertisedV6 = 
                                                                             this.MaxPrefixesAdvertisedIPv6 ?? null,
                                                                         Md5AuthenticationKey =
                                                                             this.MD5AuthenticationKey ?? null,
                                                                                                           },
                                                                         PeeringDBFacilityId = 0,

                                                                     }
                                                             }
                    }
                };


            if (this.ParameterSetName.Equals(Constants.ParameterSetNameIPv6Prefix)
                || this.ParameterSetName.Equals(Constants.ParameterSetNameIPv4Prefix))
            {
                if (PeeringRequest.Exchange.Connections[0] == null)
                    throw new PSArgumentException($"MaxPrefixAdvertisedIPv4 {this.MaxPrefixesAdvertisedIPv4} is null.");
                return (PSPeering)this.PutNewPeering(PeeringRequest);
            }
            else if (this.ParameterSetName.Equals(Constants.ParameterSetNameConvertLegacyPeering))
            {
                try
                {
                    return (PSPeering)this.PutNewPeering(this.ConvertClassicToExchangePeering(this.LegacyPeering));
                }
                catch (ArmErrorException ex)
                {
                    throw new Exception($"StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

            }
            else
            {
                Console.WriteLine($"PSPeering {this.ParameterSetName} is not recognized Try Again");
            }

            try
            {
                var Peering = PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(PeeringRequest);
                this.PeeringClient.CreateOrUpdate(this.ResourceGroupName, PeeringRequest.Name, Peering);
            }
            catch (HttpOperationException ex)
            {
                throw new Exception(
                    $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
            }

            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                    this.PeeringClient.Get(this.ResourceGroupName, this.PeeringName));
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Unable to retrieve stored Peering from EdgeRp, state was not persisted",
                    ex.InnerException);
            }
        }

        /// <summary>
        /// The put new Peering.
        /// </summary>
        /// <param name="newPeering">
        /// The new Peering.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object PutNewPeering(PSPeering newPeering)
        {
            this.PeeringClient.CreateOrUpdate(
                this.ResourceGroupName,
                this.PeeringName,
                PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(newPeering));
            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                this.PeeringClient.Get(this.ResourceGroupName, this.PeeringName));
        }

        /// <summary>
        /// The convert classic to direct peering.
        /// </summary>
        /// <param name="classicPeering">
        /// The classic peering.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private PSPeering ConvertClassicToExchangePeering(PSPeering classicPeering)
        {
            if (classicPeering == null)
                throw new ArgumentNullException("Unable to convert legacy peering because value was null or empty.");
            if (classicPeering.Exchange.Connections == null)
                throw new ArgumentNullException("Unable to convert legacy peering.");
            var connections = new List<PSExchangeConnection>();
            foreach (var sessionConfiguration in classicPeering.Exchange.Connections)
            {
                connections.Add(sessionConfiguration);
            }

            var newPeering = new PSPeering
            {
                Location = this.GetAzureRegion(this.PeeringLocation, Constants.Exchange),
                ETag = classicPeering.ETag ?? null,
                PeeringLocation =
                                              classicPeering.PeeringLocation ?? this.PeeringLocation,
                Kind = classicPeering.Kind ?? Constants.Exchange,
                Sku =
                                              classicPeering.Sku
                                              ?? new PSPeeringSku { Name = "basic_Exchange_Free" },
                Exchange = new PSPeeringPropertiesExchange
                {
                    Connections = classicPeering.Exchange.Connections, 
                    BgpCommunities = classicPeering.Exchange.BgpCommunities,
                }
            };
            return newPeering;
        }
    }
}
