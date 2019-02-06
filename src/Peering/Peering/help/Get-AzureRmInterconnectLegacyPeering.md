---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: AzureRM.Peering
online version:
schema: 2.0.0
---

# Get-AzPeeringLegacyPeering

## SYNOPSIS
Get a list of legact peerings with Microsoft that can be converted to Direct or Exchange Peering Resources.

## SYNTAX

```
Get-AzPeeringLegacyPeering [-Kind] <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Use **Get-AzPeeringLegacyPeering** cmdlet to convert legacy objects to new Direct or Exchange Peering objects. 

## EXAMPLES

### Simple Get
```powershell
PS C:\> Get-AzPeeringLegacyPeering -Kind Exchange

Name                      : legacyExchangePeering
Sku                       : Basic_Exchange_Free
Kind                      : Exchange
MaxPrefixesAdvertisedIPv4 : 0
SessionIPv4Prefix         : 10.0.0.33/32
IPv4SessionState          : Established
MaxPrefixesAdvertisedIPv6 : 0
SessionIPv6Prefix         : 2001::1/128
IPv6SessionState          : Established
Peering Location     : Amsterdam
PeeringDBFacilityId       : 26
PeeringState         : Active
ProvisioningState         : Succeeded
Id                        : /subscriptions/xxxx/resourceGroups/contoso/providers/Microsoft.Peering/Peerings/legacyExchangePee
                            ring
Type                      : Microsoft.Peering/Peerings
Tags                      : {}
```

Gets the legacy exchange peerings with Microsoft. These can be saved to powershell variables and converted to [`New-AzExchangePeering`](New-AzExchangePeering.md). See Example 2. 

### Get and Pipe to New Exchange Peering
```powershell
PS C:\> $legacy = Get-AzPeeringLegacyPeering -Kind Exchange`
PS C:\>$legacy[0] | New-AzExchangePeering -PeeringName AMSContosoExchange -ResourceGroupName ContosoAMSResourceGroup -Location westus -MaxPrefixesAdvertisedIPv4 155 -MaxPrefixesAdvertisedIPv6 2048`


Name                      : AMSContosoExchange
Sku                       : Basic_Exchange_Free
Kind                      : Exchange
MaxPrefixesAdvertisedIPv4 : 155
SessionIPv4Prefix         : 10.0.0.33/32
IPv4SessionState          : Established
MaxPrefixesAdvertisedIPv6 : 2048
SessionIPv6Prefix         : 2001::1/128
IPv6SessionState          : Established
Peering Location     : Amsterdam
PeeringDBFacilityId       : 26
PeeringState         : Active
ProvisioningState         : Succeeded
Id                        : /subscriptions/xxxx/resourceGroups/contoso/providers/Microsoft.Peering/Peerings/AMSContosoExchange
Type                      : Microsoft.Peering/Peerings
Tags                      : {}
```

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

### -Kind
Shows all Peering resource by Kind.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Direct, Exchange

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

## NOTES

## RELATED LINKS
