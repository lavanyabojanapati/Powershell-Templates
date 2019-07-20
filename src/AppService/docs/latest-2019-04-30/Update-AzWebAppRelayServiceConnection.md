---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/update-azwebapprelayserviceconnection
schema: 2.0.0
---

# Update-AzWebAppRelayServiceConnection

## SYNOPSIS
Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).

## SYNTAX

### Update (Default)
```
Update-AzWebAppRelayServiceConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-EntityName <String>] [-ConnectionEnvelope <IRelayServiceConnectionEntity>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWebAppRelayServiceConnection -InputObject <IWebSiteIdentity> [-EntityName <String>]
 [-BiztalkUri <String>] [-EntityConnectionString <String>] [-Hostname <String>] [-Kind <String>]
 [-Port <Int32>] [-ResourceConnectionString <String>] [-ResourceType <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzWebAppRelayServiceConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-EntityName <String>] [-BiztalkUri <String>] [-EntityConnectionString <String>] [-Hostname <String>]
 [-Kind <String>] [-Port <Int32>] [-PropertiesEntityName <String>] [-ResourceConnectionString <String>]
 [-ResourceType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzWebAppRelayServiceConnection -InputObject <IWebSiteIdentity>
 [-ConnectionEnvelope <IRelayServiceConnectionEntity>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BiztalkUri
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionEnvelope
Hybrid Connection for an App Service app.
To construct, see NOTES section for CONNECTIONENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IRelayServiceConnectionEntity
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EntityConnectionString
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EntityName
Name of the hybrid connection configuration.

```yaml
Type: System.String
Parameter Sets: Update, UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Hostname
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Port
HELP MESSAGE MISSING

```yaml
Type: System.Int32
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesEntityName
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceConnectionString
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceType
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IRelayServiceConnectionEntity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IRelayServiceConnectionEntity

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CONNECTIONENVELOPE <IRelayServiceConnectionEntity>: Hybrid Connection for an App Service app.
  - `[Kind <String>]`: Kind of resource.
  - `[BiztalkUri <String>]`: 
  - `[EntityConnectionString <String>]`: 
  - `[EntityName <String>]`: 
  - `[Hostname <String>]`: 
  - `[Port <Int32?>]`: 
  - `[ResourceConnectionString <String>]`: 
  - `[ResourceType <String>]`: 

## RELATED LINKS
