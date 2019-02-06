---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: AzureRm.Peering
online version:
schema: 2.0.0
---

# New-AzureRmPeering

## SYNOPSIS
Creates new Peering object or updates an already existing object.

## SYNTAX

### DeviceAWithDefaultVlan (Default)
```
New-AzureRmPeering [-AsJob] -BandwidthInMbps <Int32> -DeviceASessionIPv4Prefix <String>
 [-DeviceASessionIPv6Prefix <String>] [-Direct] -PeeringLocation <String> -PeeringName <String>
 -ResourceGroupName <String> -Sku <String> [-UseForPeeringService]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAAndBWithDefaultVlan
```
New-AzureRmPeering [-AsJob] -BandwidthInMbps <Int32> -DeviceASessionIPv4Prefix <String>
 [-DeviceASessionIPv6Prefix <String>] -DeviceBSessionIPv4Prefix <String> [-DeviceBSessionIPv6Prefix <String>]
 [-Direct] -PeeringLocation <String> -PeeringName <String> -ResourceGroupName <String> -Sku <String>
 [-UseForPeeringService] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CDNPeering
```
New-AzureRmPeering [-AsJob] -BandwidthInMbps <Int32> [-CDN] -DeviceASessionIPv4Prefix <String>
 [-DeviceASessionIPv6Prefix <String>] -DeviceBSessionIPv4Prefix <String> [-DeviceBSessionIPv6Prefix <String>]
 -PeeringLocation <String> -PeeringName <String> -ProvisionedBandwidthInMbps <Int32>
 -ResourceGroupName <String> -Sku <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PeeringService
```
New-AzureRmPeering [-AsJob] -CarrierName <String> -PeeringLocation <String>
 -PeeringName <String> -ResourceGroupName <String> -Sku <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ExchangePeering
```
New-AzureRmPeering [-AsJob] -DeviceASessionIPv4Prefix <String> [-DeviceASessionIPv6Prefix <String>]
 [-Exchange] -PeeringLocation <String> -PeeringName <String> -ResourceGroupName <String>
 -Sku <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmPeering** cmdlet creates a new Peering object.

## EXAMPLES

### Direct Peering
```powershell
PS C:\> New-AzureRmPeering -PeeringName Contoso1_SEA_Peering -ResourceGroupName Contoso1 -PeeringLocation $location[0].Properties.PeeringLocation -SKU premium_Direct_Unlimited -DeviceAName Rapter1 -UseForPeeringService -DeviceAColoId ef4 -DeviceARackId 12c -DeviceAPortId xe0/0/0 -DeviceASessionIPv4Prefix 192.168.10.2/31 -DeviceASessionIPv6Prefix fe00::e024/126 -DeviceBName Rapter2 -DeviceBColoId rd5 -DeviceBRackId 13b -DeviceBPortId xe0/0/1 -DeviceBSessionIPv4Prefix 10.2.24.99/30 -DeviceBSessionIPv6Prefix fe01::34fd/127 -BandwidthInMbps 10000
 Sku        : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringSku
Kind       : Direct
Properties : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringProperties
Name       : Contoso1_SEA_Peering
Id         : /subscriptions/XXXXXXX-61c4-436f-XXXX-XXXXXXXXX/resourceGroups/Contoso1/providers/Microsoft.Peering/in
             terconnects/Contoso1_SEA_Peering
Type       : Microsoft.Peering/Peerings
Location   :PeeringLocation_Building40
ETag       :
Tags       : {}
```

Location must be a location returned by the command Get-AzureRmPeeringLocation. You can store this as a variable $location = Get-AzureRmPeering

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BandwidthInMbps
The Bandwidth offered at this location in Mbps

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: DeviceAWithDefaultVlan, DeviceAAndBWithDefaultVlan, CDNPeering
Aliases:
Accepted values: 10000, 100000

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CarrierName
Name of Known Partner

```yaml
Type: System.String
Parameter Sets: PeeringService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CDN
The CDN Type of Peering

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CDNPeering
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceASessionIPv4Prefix
The IPv4 session Prefix

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceAAndBWithDefaultVlan, CDNPeering, ExchangePeering
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceASessionIPv6Prefix
TheIPv6sessionPrefix

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceAAndBWithDefaultVlan, CDNPeering, ExchangePeering
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceBSessionIPv4Prefix
The IPv4 session Prefix

```yaml
Type: System.String
Parameter Sets: DeviceAAndBWithDefaultVlan, CDNPeering
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceBSessionIPv6Prefix
TheIPv6sessionPrefix

```yaml
Type: System.String
Parameter Sets: DeviceAAndBWithDefaultVlan, CDNPeering
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direct
The Direct Type of Peering

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DeviceAWithDefaultVlan, DeviceAAndBWithDefaultVlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exchange
The Exchange Type of Peering

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ExchangePeering
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringLocation
The Physical Location Different from Azure Region

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringName
The unique name of the Peering

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionedBandwidthInMbps
The Bandwidth offered at this location in chunks of 10000 Mbps

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: CDNPeering
Aliases:
Accepted values: 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU Tier

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: basic_Exchange_Free, basic_Direct_Free, premium_Direct_Metered, premium_Direct_Unlimited, premium_Direct_Free, premium_Carrier_Metered, premium_CDN_Unlimited

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseForPeeringService
Offer Peering to subscribing customers

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DeviceAWithDefaultVlan, DeviceAAndBWithDefaultVlan
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeering

## NOTES

## RELATED LINKS
