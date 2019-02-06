---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.dll-Help.xml
Module Name: Az.Peering
online version:
schema: 2.0.0
---

# Get-AzPeeringLegacyDirectPeering

## SYNOPSIS
Get a list of legact peerings with Microsoft that can be converted to Direct Peering Resources.

## SYNTAX

```
Get-AzPeeringLegacyDirectPeering [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Use **Get-AzPeeringLegacyDirectPeering** cmdlet to convert legacy objects to new Direct Peering objects. 

## EXAMPLES

### Example 1:List
```powershell
PS C:\> Get-AzPeeringLegacyDirectPeering
```

Lists Legacy Direct Peering Objects

### Example 2:
```powershell
PS C:\> Get-AzPeeringLegacyDirectPeering | foreach {New-AzPeering -Name $_.Properties.PeeringLocation.Insert(0,"Peering") -ResourceGroupName rg0 -DeviceLocation $_.Properties.PeeringLocation -SkuName $_.Sku.Name -Tier $_.Sku.Tier -Family $_.Sku.Family -Size $_.Sku.Size -DeviceName Rapter1,Rapter2 -coloId 1ed,2ed -rackId a,b -portId 1,2,3,4,5 -SessionIPv4Prefix $_.Properties.Direct.ADeviceSession.SessionIPv4Prefix,$_.Properties.Direct.BDeviceSession.SessionIPv4Prefix -SessionIPv6Prefix $_.Properties.Direct.ADeviceSession.SessionIPv6Prefix,$_.Properties.Direct.BDeviceSession.SessionIPv6Prefix -Bandwidth $_.Properties.Direct.BandwidthInGpbs -AsJob -Force}
```

Converts all existing Legacy Direct Peerings into Peering objects. 

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

## NOTES

## RELATED LINKS
