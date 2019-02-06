namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    /// <summary>
    /// Constants Class for Powershell 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// None
        /// </summary>
        public const string None = "None";

        /// <summary>
        /// Active
        /// </summary>
        public const string Active = "Active";

        /// <summary>
        /// Pending Add
        /// </summary>
        public const string PendingAdd = "PendingAdd";

        /// <summary>
        /// Pending Remove
        /// </summary>
        public const string PendingRemove = "PendingRemove";

        /// <summary>
        /// Provisioning Started
        /// </summary>
        public const string ProvisioningStarted = "ProvisioningStarted";

        /// <summary>
        /// Provisioning Completed
        /// </summary>
        public const string ProvisioningCompleted = "ProvisioningCompleted";

        /// <summary>
        /// Provisioning Failed
        /// </summary>
        public const string ProvisioningFailed = "ProvisioningFailed";

        /// <summary>
        /// Provisioning Failed
        /// </summary>
        public const string CarrierApproved = "CarrierApproved";
        
        /// <summary>
        /// Removed
        /// </summary>
        public const string Removed = "Removed";

        /// <summary>
        /// Succeeded
        /// </summary>
        public const string Succeeded = "Succeeded";

        /// <summary>
        /// Enabled
        /// </summary>
        public const string Enabled = "Enabled";

        /// <summary>
        /// Disabled
        /// </summary>
        public const string Disabled = "Disabled";

        /// <summary>
        /// The Partner Parameter set name
        /// </summary>
        public const string Partner = "Partner";

        /// <summary>
        /// The CDN Parameter set name.
        /// </summary>
        public const string CDN = "CDN";

        /// <summary>
        /// The Direct Peering Parameter set name.
        /// </summary>
        public const string Direct = "Direct";

        /// <summary>
        /// The exchange Parameter set name
        /// </summary>
        public const string Exchange = "Exchange";

        //Help Messages 
        /// <summary>
        /// ResourceGroupNameHelp
        /// </summary>
        public const string ResourceGroupNameHelp = "The resource group name.";

        /// <summary>
        /// PeeringNameHelp
        /// </summary>
        public const string PeeringNameHelp = "The unique name of the PSPeering.";

        /// <summary>
        /// The location help.
        /// </summary>
        public const string LocationHelp = "The location of the resource.";

        /// <summary>
        /// PeeringLocationHelp
        /// </summary>
        public const string PeeringLocationHelp =
            "The Physical Location Different from Azure Region. Use Get-AzureRmPeeringLocation -Kind <kind> use City name as key.";

        /// <summary>
        /// HelpSku
        /// </summary>
        public const string HelpSku = "The SKU Tier.";

        /// <summary>
        /// Gets or sets the help peering db facility id.
        /// </summary>
        public const string HelpPeeringDbFacilityId = "The peering facility Id found on https://peeringdb.com";

        /// <summary>
        /// IPv4Help
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string IPv4Help = "The IPv4 session Prefix.";

        /// <summary>
        /// IPv6Help
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string IPv6Help = "TheIPv6sessionPrefix.";

        /// <summary>
        /// BandwidthHelp
        /// </summary>
        public const string BandwidthHelp = "The Bandwidth offered at this location in Mbps.";

        /// <summary>
        /// AsJobHelp
        /// </summary>
        public const string AsJobHelp = "Run in the background.";

        /// <summary>
        /// KindHelp
        /// </summary>
        public const string KindHelp = "Shows all Peering resource by Kind.";

        /// <summary>
        /// SubscriberNameHelp
        /// </summary>
        public const string SubscriberNameHelp = "Name of carrier subscriber.";

        /// <summary>
        /// ProvisionedBandwidthHelp
        /// </summary>
        public const string ProvisionedBandwidthHelp = "The Bandwidth offered at this location in chunks of 10000 Mbps";

        /// <summary>
        /// The m d 5 authentication key position.
        /// </summary>
        public const int PositionMd5AuthenticationKey = 6;

        /// <summary>
        /// The position sku.
        /// </summary>
        public const int PositionSku = 5;

        /// <summary>
        /// The position peering db facility id.
        /// </summary>
        public const int PositionPeeringDbFacilityId = 4;

        /// <summary>
        /// The position Peering location.
        /// </summary>
        public const int PositionPeeringLocation = 3;

        /// <summary>
        /// The position location.
        /// </summary>
        public const int PositionLocation = 2;

        /// <summary>
        /// The position resource group name.
        /// </summary>
        public const int PositionResourceGroupName = 1;

        /// <summary>
        /// The position Peering name.
        /// </summary>
        public const int PositionPeeringName = 0;

        //ParameterSetNames for new direct Peering
        /// <summary>
        /// DeviceAAndBWithDefaultVlan ParameterSetName Enum 1
        /// </summary>
        public const string DeviceAWithDefaultVlan = "DeviceAWithDefaultVlan";

        /// <summary>
        /// DeviceAAndBWithDefaultVlan ParameterSetName Enum 2
        /// </summary>
        public const string DeviceBWithDefaultVlan = "DeviceBWithDefaultVlan";

        /// <summary>
        /// VlanAI ParameterSetName Enum 4
        /// </summary>
        public const string DeviceAWithPeeringVlan = "DeviceAWithPeeringVlan";

        /// <summary>
        /// VlanAI ParameterSetName Enum 6
        /// </summary>
        public const string DeviceBWithPeeringVlan = "DeviceBWithPeeringVlan";

        /// <summary>
        /// DeviceAAndBWithDefaultVlan ParameterSetName Enum 3
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string DeviceAAndBWithDefaultVlan = "DeviceAAndBWithDefaultVlan";

        /// <summary>
        /// VlanAandBI ParameterSetName Enum 10
        /// </summary>
        public const string DeviceAAndBWithPeeringVlan = "DeviceAAndBWithPeeringVlan";

        /// <summary>
        /// DeviceAWithDefaultAndPeeringVlan ParameterSetName Enum 5
        /// </summary>
        public const string DeviceAWithDefaultAndPeeringVlan = "DeviceAWithDefaultAndPeeringVlan";

        /// <summary>
        /// DeviceAWithDefaultAndPeeringVlan ParameterSetName Enum 8
        /// </summary>
        public const string DeviceBWithDefaultAndPeeringVlan = "DeviceBWithDefaultAndPeeringVlan";

        /// <summary>
        /// DeviceAAndBWithDefaultAndPeeringVlan ParameterSetName Enum 13
        /// </summary>
        public const string DeviceAAndBWithDefaultAndPeeringVlan = "DeviceAAndBWithDefaultAndPeeringVlan";

        // With V6 mandatory

        /// <summary>
        /// The device A with Peering with v6.
        /// </summary>
        public const string DeviceAAndBWithPeeringVlanV6 = "DeviceAAndBWithPeeringVlanV6";

        /// <summary>
        /// The device a and b with default and Peering vlan v 6.
        /// </summary>
        public const string DeviceAAndBWithDefaultAndPeeringVlanV6 = "DeviceAAndBWithDefaultAndPeeringVlanV6";

        /// <summary>
        /// CDNPeering ParameterSetName
        /// </summary>
        public const string CdnPeering = "CDNPeering";

        /// <summary>
        /// CDNPeering2 ParameterSetName
        /// </summary>
        public const string CdnPeering2 = "CDNPeering2";

        /// <summary>
        /// Partner Peering ParameterSetName
        /// </summary>
        public const string PeeringService = "PeeringService";

        /// <summary>
        /// Exchange Peering ParameterSetName
        /// </summary>
        public const string ExchangePeering = "ExchangePeering";

        /// <summary>
        /// ParameterSetName for GetPeering
        /// </summary>
        public const string PeeringByResource = "PeeringByResource";

        /// <summary>
        /// ParameterSetName for PeeringByResourceIPPrefixes
        /// </summary>
        public const string PeeringByResourceIpPrefixes = "PeeringByResourceIPPrefixes";

        /// <summary>
        /// Parameter set name for PeeringByResourceAndName
        /// </summary>
        public const string PeeringByResourceAndName = "PeeringByResourceAndName";

        /// <summary>
        /// Parameter set name PeeringByKind
        /// </summary>
        public const string PeeringByKind = "PeeringByKind";

        /// <summary>
        /// Continue Message for Peering Removal.
        /// </summary>
        public const string ContinueMessage = "You are about to remove an Peering Resource. Are you sure?";

        /// <summary>
        /// Processing Message for Peering Removal.
        /// </summary>
        public const string ProcessMessage = "Peering {PeeringName} Resource being removed.";

        /// <summary>
        /// The MD5 hash for authentication between the peers.
        /// </summary>
        public const string HelpMD5AuthenticationKey = "The MD5 authentication key for session.";

        /// <summary>
        /// The min range.
        /// </summary>
        public const int MinRange = 10000;

        /// <summary>
        /// The max range.
        /// </summary>
        public const int MaxRange = 100000;

        /// <summary>
        /// The by subscription.
        /// </summary>
        public const string BySubscription = "BySubscription";

        /// <summary>
        /// The parameter set name prefix.
        /// </summary>
        public const string ParameterSetNamePrefix = "ParameterSetNamePrefix";

        /// <summary>
        /// The prefix help.
        /// </summary>
        public const string PrefixHelp = "The prefix for a metro region.";

        /// <summary>
        /// The metro help.
        /// </summary>
        public const string MetroHelp = "The name of the Metro.";

        /// <summary>
        /// The prefix name help.
        /// </summary>
        public const string PrefixNameHelp = "The name of prefix.";

        /// <summary>
        /// The parameter set name prefix by Peering.
        /// </summary>
        public const string ParameterSetNamePrefixByPeering = "ParameterSetNamePrefixByPeering";

        /// <summary>
        /// The parameter set name prefix by prefix name.
        /// </summary>
        public const string ParameterSetNamePrefixByPrefixName = "ParameterSetNamePrefixByPrefixName";

        /// <summary>
        /// The Peering state help.
        /// </summary>
        public const string PeeringStateHelp = "The Peering state of a subscriber.";

        /// <summary>
        /// The parameter set name convert legacy Peering.
        /// </summary>
        public const string ParameterSetNameConvertLegacyPeering = "ParameterSetNameConvertLegacyPeering";

        public enum PeeringPermutations
        {
            /// <summary>
            /// The b device default vlan.
            /// </summary>
            BDeviceDefaultVlan,

            /// <summary>
            /// The a device default vlan.
            /// </summary>
            ADeviceDefaultVlan,

            /// <summary>
            /// The a device Peering vlan.
            /// </summary>
            ADevicePeeringVlan,

            /// <summary>
            /// The b device Peering vlan.
            /// </summary>
            BDevicePeeringVlan,

            /// <summary>
            /// The aand b device default vlan.
            /// </summary>
            AandBDeviceDefaultVlan,

            /// <summary>
            /// The a and b device default vlan.
            /// </summary>
            AandBDevicePeeringVlan,

            /// <summary>
            /// The aor b device default and Peering vlan.
            /// </summary>
            ADeviceDefaultAndPeeringVlan,

            /// <summary>
            /// The b device default and Peering vlan.
            /// </summary>
            BDeviceDefaultAndPeeringVlan,

            /// <summary>
            /// The aand b device default and Peering vlan.
            /// </summary>
            AandBDeviceDefaultAndPeeringVlan,

            /// <summary>
            /// The failed.
            /// </summary>
            Failed = 99
        }

        /// <summary>
        /// The parameter set name i pv 6 prefix.
        /// </summary>
        public const string ParameterSetNameIPv6Prefix = "ParameterSetNameIPv6Prefix";

        /// <summary>
        /// The help max advertised i pv 4.
        /// </summary>
        public const string HelpMaxAdvertisedIPv4 = "HelpMaxAdvertisedIPv4";

        /// <summary>
        /// The parameter set name i pv 4 prefix.
        /// </summary>
        public const string ParameterSetNameIPv4Prefix = "ParameterSetNameIPv4Prefix";

        /// <summary>
        /// The help max advertised i pv 6.
        /// </summary>
        public const string HelpMaxAdvertisedIPv6 = "HelpMaxAdvertisedIPv6";

        /// <summary>
        /// The help session i pv 4 prefix.
        /// </summary>
        public const string HelpSessionIPv4Prefix = "HelpSessionIPv4Prefix";

        /// <summary>
        /// The help session i pv 6 prefix.
        /// </summary>
        public const string HelpSessionIPv6Prefix = "HelpSessionIPv6Prefix";
    }
}