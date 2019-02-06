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
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models;
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
    [Cmdlet(VerbsCommon.New, "AzureRmDirectPeering", DefaultParameterSetName = Constants.DeviceAWithDefaultVlan)]
    [OutputType(typeof(PSPeering))]
    public class NewAzureDirectPeeringCommand : PeeringBaseCmdlet
    {
        private PSPeeringPropertiesDirect propertiesDirect = new PSPeeringPropertiesDirect();

        /// <summary>
        /// Gets or sets the legacy Peering.
        /// </summary>
        [Parameter(Mandatory = true,
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
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
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
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Position = Constants.PositionResourceGroupName,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets The Peering Location.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Position = Constants.PositionPeeringLocation,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringLocation { get; set; }

        /// <summary>
        ///     Gets or sets The Peering Location.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Position = Constants.PositionPeeringDbFacilityId,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDbFacilityId,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ValidateNotNullOrEmpty]
        public virtual uint PeeringDBFacilityId { get; set; }

        /// <summary>
        ///     Gets or sets the Sku for the Peering.
        /// </summary>
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Position = Constants.PositionSku,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpSku,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [PSArgumentCompleter(
            "basic_Direct_Free",
            "premium_Direct_Free")]
        [ValidateSet(
            "basic_Direct_Free",
            "premium_Direct_Free",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public virtual string Sku { get; set; }

        /// <summary>
        ///     Gets or sets the Sku for the Peering.
        /// </summary>
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Position = Constants.PositionMd5AuthenticationKey,
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpMD5AuthenticationKey,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        public string MD5AuthenticationKey { get; set; }

        /// <summary>
        ///     Ipv4 Session Prefix
        /// </summary>
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ValidateNotNullOrEmpty]
        public virtual string DefaultVlanDeviceASessionIPv4Prefix { get; set; }

        /// <summary>
        ///     IPV6SessionPrefix
        /// </summary>
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        public virtual string DefaultVlanDeviceASessionIPv6Prefix { get; set; }

        /// <summary>
        ///     Ipv4 Session Prefix
        /// </summary>
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ValidateNotNullOrEmpty]
        public virtual string DefaultVlanDeviceBSessionIPv4Prefix { get; set; }

        /// <summary>
        ///     IPV6SessionPrefix
        /// </summary>
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        public virtual string DefaultVlanDeviceBSessionIPv6Prefix { get; set; }

        /// <summary>
        ///     Bandwidth offered at this location.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceAWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceBWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [PSArgumentCompleter("10000", "20000", "30000", "40000", "50000", "60000", "70000", "80000", "90000", "100000")]
        [ValidateRange(Constants.MinRange, Constants.MaxRange)]
        [ValidateNotNullOrEmpty]
        public virtual int? DefaultVlanBandwidthInMbps { get; set; }

        /// <summary>
        ///     Ipv4 Session Prefix
        /// </summary>
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringVlanDeviceASessionIPv4Prefix { get; set; }

        /// <summary>
        ///     IPV6SessionPrefix
        /// </summary>
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        public virtual string PeeringVlanDeviceASessionIPv6Prefix { get; set; }

        /// <summary>
        ///     Ipv4 Session Prefix
        /// </summary>
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv4Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringVlanDeviceBSessionIPv4Prefix { get; set; }

        /// <summary>
        ///     IPV6SessionPrefix
        /// </summary>
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceBWithPeeringVlan)]
        [Parameter(
            Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceBWithDefaultAndPeeringVlan)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithPeeringVlanV6)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.IPv6Help,
            ParameterSetName = Constants.DeviceAAndBWithDefaultAndPeeringVlanV6)]
        public virtual string PeeringVlanDeviceBSessionIPv6Prefix { get; set; }

        /// <summary>
        ///     Bandwidth offered at this location.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.BandwidthHelp,
            ParameterSetName = Constants.DeviceAWithPeeringVlan)]
        [PSArgumentCompleter("10000", "20000", "30000", "40000", "50000", "60000", "70000", "80000", "90000", "100000")]
        [ValidateRange(Constants.MinRange, Constants.MaxRange)]
        [ValidateNotNullOrEmpty]
        public virtual int? BandwidthInMbps { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var PeeringRequest = this.CreatePeering();
            this.WriteObject(PeeringRequest);
        }

        /// <summary>
        /// The create Peering.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        private PSPeering CreatePeering()
        {
            var PeeringRequest = new PSPeering(name: this.PeeringName)
            {
                PeeringLocation = this.PeeringLocation,
                Location = this.GetAzureRegion(this.PeeringLocation, Constants.Direct),
                Direct = new PSPeeringPropertiesDirect(),
                Kind = Constants.Direct,
                Sku = new PSPeeringSku { Name = this.Sku }
            };

            PeeringRequest.Direct.Connections = new List<PSDirectConnection>();

            if (this.ParameterSetName.Equals(Constants.DeviceAAndBWithDefaultAndPeeringVlanV6))
            {

            }
            else if (this.ParameterSetName.Equals(Constants.ParameterSetNameConvertLegacyPeering))
            {
                try
                {
                    return (PSPeering)this.PutNewPeering(
                        this.ConvertClassicToDirectPeering(this.LegacyPeering));
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

            PeeringRequest.Direct = this.propertiesDirect;

            try
            {
                this.PutNewPeering(PeeringRequest);
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
        private PSPeering ConvertClassicToDirectPeering(PSPeering classicPeering)
        {
            if (classicPeering.Direct == null)
                throw new ArgumentNullException("Unable to convert legacy peering because value was null or empty.");
            var newPeering = new PSPeering
            {
                PeeringLocation = classicPeering.PeeringLocation ?? this.PeeringLocation,
                Kind = classicPeering.Kind,
                Sku = classicPeering.Sku,
                Location = this.GetAzureRegion(classicPeering.PeeringLocation ?? this.PeeringLocation, Constants.Direct)
            };

            if (classicPeering.Direct.Connections != null)
            {
                newPeering.Direct = new PSPeeringPropertiesDirect
                {
                    UseForPartnerPeering = true,
                    Connections = new List<PSDirectConnection>(),
                    BgpCommunities = new List<PSBgpCommunity>()
                };
            }
            return newPeering;
        }
    }

}
