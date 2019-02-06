---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: AzureRM.Peering
online version:
schema: 2.0.0
---

# New-AzureRmDirectPeering

## SYNOPSIS
Create or convert to a new Direct Peering resource in Azure.

## SYNTAX

### DeviceAWithDefaultVlan (Default)
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceASessionIPv4Prefix <String>
 [-DefaultVlanDeviceASessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ParameterSetNameConvertLegacyPeering
```
New-AzureRmDirectPeering -LegacyPeering <PSPeering> [-PeeringName] <String>
 [-ResourceGroupName] <String> [-Location] <String> [-PeeringLocation] <String>
 [-PeeringDBFacilityId] <UInt32> [[-MD5AuthenticationKey] <String>] [-DefaultVlanBandwidthInMbps <Int32>]
 [-PeeringVlanBandwidthInMbps <Int32>] [-BandwidthInMbps <Int32>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceBWithDefaultVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceBSessionIPv4Prefix <String>
 [-DefaultVlanDeviceBSessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAWithPeeringVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -PeeringVlanDeviceASessionIPv4Prefix <String>
 [-PeeringVlanDeviceASessionIPv6Prefix <String>] -PeeringVlanBandwidthInMbps <Int32>
 -BandwidthInMbps <Int32> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceBWithPeeringVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -PeeringVlanDeviceBSessionIPv4Prefix <String>
 [-PeeringVlanDeviceBSessionIPv6Prefix <String>] -PeeringVlanBandwidthInMbps <Int32>
 -BandwidthInMbps <Int32> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAWithDefaultAndPeeringVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceASessionIPv4Prefix <String>
 [-DefaultVlanDeviceASessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32>
 -PeeringVlanDeviceASessionIPv4Prefix <String> [-PeeringVlanDeviceASessionIPv6Prefix <String>]
 -PeeringVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceBWithDefaultAndPeeringVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceBSessionIPv4Prefix <String>
 [-DefaultVlanDeviceBSessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32>
 -PeeringVlanDeviceBSessionIPv4Prefix <String> [-PeeringVlanDeviceBSessionIPv6Prefix <String>]
 -PeeringVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAAndBWithDefaultVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceASessionIPv4Prefix <String>
 [-DefaultVlanDeviceASessionIPv6Prefix <String>] -DefaultVlanDeviceBSessionIPv4Prefix <String>
 [-DefaultVlanDeviceBSessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAAndBWithPeeringVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -PeeringVlanDeviceASessionIPv4Prefix <String>
 -PeeringVlanDeviceBSessionIPv4Prefix <String> -PeeringVlanBandwidthInMbps <Int32>
 -BandwidthInMbps <Int32> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAAndBWithDefaultAndPeeringVlan
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceASessionIPv4Prefix <String>
 [-DefaultVlanDeviceASessionIPv6Prefix <String>] -DefaultVlanDeviceBSessionIPv4Prefix <String>
 [-DefaultVlanDeviceBSessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32>
 -PeeringVlanDeviceASessionIPv4Prefix <String> -PeeringVlanDeviceBSessionIPv4Prefix <String>
 -PeeringVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAAndBWithPeeringVlanV6
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -PeeringVlanDeviceASessionIPv4Prefix <String>
 -PeeringVlanDeviceASessionIPv6Prefix <String> -PeeringVlanDeviceBSessionIPv4Prefix <String>
 -PeeringVlanDeviceBSessionIPv6Prefix <String> -PeeringVlanBandwidthInMbps <Int32>
 -BandwidthInMbps <Int32> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DeviceAAndBWithDefaultAndPeeringVlanV6
```
New-AzureRmDirectPeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-PeeringLocation] <String> [-PeeringDBFacilityId] <UInt32> [-Sku] <String>
 [[-MD5AuthenticationKey] <String>] -DefaultVlanDeviceASessionIPv4Prefix <String>
 [-DefaultVlanDeviceASessionIPv6Prefix <String>] -DefaultVlanDeviceBSessionIPv4Prefix <String>
 [-DefaultVlanDeviceBSessionIPv6Prefix <String>] -DefaultVlanBandwidthInMbps <Int32>
 -PeeringVlanDeviceASessionIPv4Prefix <String> -PeeringVlanDeviceASessionIPv6Prefix <String>
 -PeeringVlanDeviceBSessionIPv4Prefix <String> -PeeringVlanDeviceBSessionIPv6Prefix <String>
 -PeeringVlanBandwidthInMbps <Int32> -BandwidthInMbps <Int32> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create or convert to new Direct Peering Resource in Azure.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmDirectPeering -PeeringName ContosoDirectLAX -ResourceGroupName test -Location westus -PeeringLocation "Los Angeles" -PeeringDBFacilityId 8 -Sku basic_Direct_Free -MD5AuthenticationKey SomeHashContoso -DefaultVlanDeviceASessionIPv4Prefix 10.0.0.3/31 -DefaultVlanBandwidthInMbps 10000 -BandwidthInMbps 10000
```
Creates a new Direct Peering at Los Angeles. See [Get-AzureRmPeeringLocation](Get-AzureRmPeeringLocation.md) for more information. 
## PARAMETERS

### -AsJob
Run in the background.

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
The Bandwidth offered at this location in Mbps.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -DefaultVlanBandwidthInMbps
The Bandwidth offered at this location in Mbps.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultVlanDeviceASessionIPv4Prefix
The IPv4 session Prefix.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceAWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultVlanDeviceASessionIPv6Prefix
TheIPv6sessionPrefix.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceAWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultVlanDeviceBSessionIPv4Prefix
The IPv4 session Prefix.

```yaml
Type: System.String
Parameter Sets: DeviceBWithDefaultVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultVlanDeviceBSessionIPv6Prefix
TheIPv6sessionPrefix.

```yaml
Type: System.String
Parameter Sets: DeviceBWithDefaultVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringLocation
The Physical Location Different from Azure Region.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringName
The unique name of the PSPeering.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringVlanBandwidthInMbps
The Bandwidth offered at this location in Mbps.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringVlanDeviceASessionIPv4Prefix
The IPv4 session Prefix.

```yaml
Type: System.String
Parameter Sets: DeviceAWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringVlanDeviceASessionIPv6Prefix
TheIPv6sessionPrefix.

```yaml
Type: System.String
Parameter Sets: DeviceAWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringVlanDeviceBSessionIPv4Prefix
The IPv4 session Prefix.

```yaml
Type: System.String
Parameter Sets: DeviceBWithPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringVlanDeviceBSessionIPv6Prefix
TheIPv6sessionPrefix.

```yaml
Type: System.String
Parameter Sets: DeviceBWithPeeringVlan, DeviceBWithDefaultAndPeeringVlan
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LegacyPeering
{{Fill LegacyPeering Description}}

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeering
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the resource.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MD5AuthenticationKey
The MD5 authentication key for session.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringDBFacilityId
The peering facility Id found on https://peeringdb.com

```yaml
Type: System.UInt32
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.UInt32
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Sku
The SKU Tier.

```yaml
Type: System.String
Parameter Sets: DeviceAWithDefaultVlan, DeviceBWithDefaultVlan, DeviceAWithPeeringVlan, DeviceBWithPeeringVlan, DeviceAWithDefaultAndPeeringVlan, DeviceBWithDefaultAndPeeringVlan, DeviceAAndBWithDefaultVlan, DeviceAAndBWithPeeringVlan, DeviceAAndBWithDefaultAndPeeringVlan, DeviceAAndBWithPeeringVlanV6, DeviceAAndBWithDefaultAndPeeringVlanV6
Aliases:
Accepted values: basic_Direct_Free, premium_Direct_Metered, premium_Direct_Unlimited, premium_Direct_Free

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeering

### System.String

### System.UInt32

### System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeering

## NOTES

## RELATED LINKS
