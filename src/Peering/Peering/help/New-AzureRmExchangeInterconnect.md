---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: AzureRM.Peering
online version:
schema: 2.0.0
---

# New-AzExchangePeering

## SYNOPSIS
Create a new Exchange Peering Resource in Azure Resource Manager.

## SYNTAX

### DeviceAWithDefaultVlan (Default)
```
New-AzExchangePeering [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ConvertLegacyPeering
```
New-AzExchangePeering -LegacyPeering <PSPeering> [-PeeringName] <String>
 [-ResourceGroupName] <String> [-Location] <String> [[-MD5AuthenticationKey] <String>]
 -MaxPrefixesAdvertisedIPv4 <Int32> [-MaxPrefixesAdvertisedIPv6 <Int32>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ConvertLegacyPeeringIPv6Prefix
```
New-AzExchangePeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [[-MD5AuthenticationKey] <String>] -MaxPrefixesAdvertisedIPv4 <Int32> -MaxPrefixesAdvertisedIPv6 <Int32>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IPv4Prefix
```
New-AzExchangePeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [[-PeeringLocation] <String>] [[-PeeringDBFacilityId] <Int32>] [[-MD5AuthenticationKey] <String>]
 -MaxPrefixesAdvertisedIPv4 <Int32> [-MaxPrefixesAdvertisedIPv6 <Int32>] -SessionIPv4Prefix <String>
 [-SessionIPv6Prefix <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IPv6Prefix
```
New-AzExchangePeering [-PeeringName] <String> [-ResourceGroupName] <String> [-Location] <String>
 [[-PeeringLocation] <String>] [[-PeeringDBFacilityId] <Int32>] [[-MD5AuthenticationKey] <String>]
 -MaxPrefixesAdvertisedIPv4 <Int32> -MaxPrefixesAdvertisedIPv6 <Int32> -SessionIPv4Prefix <String>
 -SessionIPv6Prefix <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzExchangePeering** cmdlet creates new Peering objects in ARM. This cmdlet also allows users to convert from classic models into ARM.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzExchangePeering -PeeringName ContosoExchangeAMS -ResourceGroupName ContosoResourceGroupName -Location europewest -PeeringLocation AMS -PeeringDBFacilityId 26 -MD5AuthenticationKey SomeHashContoso -MaxPrefixesAdvertisedIPv4 250 -SessionIPv4Prefix 10.0.0.3/32

```

Creates a new Exchange Peering with Microsoft at Peering Facility 26. [Get-AzPeeringLocation](Get-AzPeeringLocation.md) has more information on Peering locations.

### Example 2
```powershell
PS C:\> New-AzExchangePeering -PeeringName ContosoExchangeAMS -ResourceGroupName ContosoResourceGroupName -Location europewest -MD5AuthenticationKey SomeHashContoso -MaxPrefixesAdvertisedIPv4 250 -MaxPrefixesAdvertisedIPv6 5000

```

Converts an exisiting Exchange Peering to an ARM Resource

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringLocation
The Physical Location Different from Azure Region.
Use Get-AzPeeringLocation -Kind \<kind\> use City name as key.

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringName
The unique name of the PSPeering.

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering, ParameterSetNameConvertLegacyPeeringParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LegacyPeering
{{Fill LegacyPeering Description}}

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering
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
Parameter Sets: ParameterSetNameConvertLegacyPeering, ParameterSetNameConvertLegacyPeeringParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrefixesAdvertisedIPv4
HelpMaxAdvertisedIPv4

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameConvertLegacyPeering, ParameterSetNameConvertLegacyPeeringParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrefixesAdvertisedIPv6
HelpMaxAdvertisedIPv6

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
Parameter Sets: ParameterSetNameConvertLegacyPeeringParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameIPv4Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MD5AuthenticationKey
The MD5 authentication key for session.

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering, ParameterSetNameConvertLegacyPeeringParameterSetNameIPv6Prefix
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringDBFacilityId
The peering facility Id found on https://peeringdb.com

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ParameterSetNameConvertLegacyPeering, ParameterSetNameConvertLegacyPeeringParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionIPv4Prefix
HelpSessionIPv4Prefix

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix, ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SessionIPv6Prefix
HelpSessionIPv6Prefix

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

### System.String

### System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

## NOTES

## RELATED LINKS
