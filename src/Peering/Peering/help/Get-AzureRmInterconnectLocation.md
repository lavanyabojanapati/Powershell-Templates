---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: AzureRM.Peering
online version:
schema: 2.0.0
---

# Get-AzPeeringLocation

## SYNOPSIS
Get locations of Peering sites 

## SYNTAX

```
Get-AzPeeringLocation [-Kind] <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPeeringLocation** cmdlet gets locations of Peerings

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzPeeringLocation

Properties : Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeeringLocationProperties
Name       : PeeringLocation_Building40
Id         :
Type       : Microsoft.Peering/PeeringLocations
Location   :
ETag       :
Tags       : {}

Properties : Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeeringLocationProperties
Name       : PeeringLocation_Building41
Id         :
Type       : Microsoft.Peering/PeeringLocations
Location   :
ETag       :
Tags       : {}


Properties : Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeeringLocationProperties
Name       : PeeringLocation_Building42
Id         :
Type       : Microsoft.Peering/PeeringLocations
Location   :
ETag       :
Tags       : {}
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
Shows Peering location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Partner, CDN, Direct, Exchange

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeeringLocation

## NOTES

## RELATED LINKS
