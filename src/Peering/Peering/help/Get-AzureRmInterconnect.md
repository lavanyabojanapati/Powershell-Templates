---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: AzureRM.Peering
online version:
schema: 2.0.0
---

# Get-AzureRmPeering

## SYNOPSIS
Get ARM Peerings for a subscription.

## SYNTAX

### BySubscription (Default)
```
Get-AzureRmPeering [-ResourceGroupName <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### PeeringByResourceAndName
```
Get-AzureRmPeering -PeeringName <String> -ResourceGroupName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PeeringByResourceIPPrefixes
```
Get-AzureRmPeering -PeeringName <String> -ResourceGroupName <String> [-Prefixes] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PeeringByResource
```
Get-AzureRmPeering -ResourceGroupName <String> [-Kind <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PeeringByKind
```
Get-AzureRmPeering -Kind <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPeering** cmdlet gets the Peerings of the subscription, resource group, or specific Peering name.

## EXAMPLES

### Example 1: Get Peering for Subscriptions
```powershell
PS C:\> Get-AzureRmPeering
Name                      : ContosoDirectLAX
Sku                       : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringSku
Kind                      : Direct
Id                        : /subscriptions/XXXX/resourceGroups/Contoso0/providers/Microsoft.Peering/Peerings/Contoso0Peeringbldg41
Type                      : Microsoft.Peering/Peerings
Location                  :LAX
ETag                      :
Tags                      : {}

Name                      : ContosoExchangeAMS
Sku                       : Basic_Exchange_Free
Kind                      : Exchange
MaxPrefixesAdvertisedIPv4 : 10
SessionIPv4Prefix         : 193.239.118.46/32
IPv4SessionState          : Established
MaxPrefixesAdvertisedIPv6 : 10
SessionIPv6Prefix         : 2001:7f8:13::a520:2954:1/128
IPv6SessionState          : Established
Md5AuthenticationKey      : md5hash
Peering Location     : Amsterdam
PeeringDBFacilityId       : 64
PeeringState         : Active
ProvisioningState         : Succeeded
Id                        : /subscriptions/XXXX/resourceGroups/Contoso1/providers/Microsoft
                            .Peering/Peerings/ContosoExchangeAMS
Type                      : Microsoft.Peering/Peerings
Tags                      : {}
```
Gets Peering for subscription.
### Example 2: Get Peering for Resource Group
```powershell
PS C:\> Get-AzureRmPeering -Kind Direct -ResourceGroupName Contoso1
Sku        : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringSku
Kind       : Direct
Properties : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringProperties
Name       : Contoso1Peeringbldg40
Id         : /subscriptions/XXXX/resourceGroups/Contoso1/providers/Microsoft.Peering/in
             terconnects/Contoso1Peeringbldg40
Type       : Microsoft.Peering/Peerings
Location   :SEA
ETag       :
Tags       : {}
```

Gets Peering by Resource Group name.

### Example 3: Get Peering details
```powershell
PS C:\> Get-AzureRmPeering -Name MyTinyPeering -ResourceGroupName Contoso1
Sku        : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringSku
Kind       : Direct
Properties : Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeeringProperties
Name       : MyTinyPeering
Id         : /subscriptions/XXXX/resourceGroups/Contoso1/providers/Microsoft.Peering/in
             terconnects/MyTinyPeering
Type       : Microsoft.Peering/Peerings
Location   :SEA
ETag       :
Tags       : {}
```

Gets Peering Resources by name and Resource Group name.

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
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringName
Name of PSPeering Resource

```yaml
Type: System.String
Parameter Sets: PeeringByResourceAndName, PeeringByResourceIPPrefixes
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Kind
Shows all Peering resource by Kind

```yaml
Type: System.String
Parameter Sets: PeeringByResource
Aliases:
Accepted values: Direct, Partner, CDN

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: PeeringByKind
Aliases:
Accepted values: Direct, Partner, CDN

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Prefixes
Expand all Prefixes

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PeeringByResourceIPPrefixes
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: BySubscription
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: PeeringByResourceAndName, PeeringByResourceIPPrefixes, PeeringByResource
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

### System.String

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models.PSPeering

## NOTES

## RELATED LINKS
