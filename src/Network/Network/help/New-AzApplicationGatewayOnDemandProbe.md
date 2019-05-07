---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzApplicationGatewayOnDemandProbe

## SYNOPSIS
Creates Application Gateway OnDemandProbe object

## SYNTAX

```
New-AzApplicationGatewayOnDemandProbe -Protocol <String> [-HostName <String>] -Path <String> -Timeout <Int32>
 [-PickHostNameFromBackendHttpSettings] [-Match <PSApplicationGatewayProbeHealthResponseMatch>]
 -BackendPoolName <String> -BackendHttpSettingName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayOnDemandProbe** create OnDemandProbe object which can be used as input parameter for **Get-AzApplicationGatewayBackendHealthOnDemand**

## EXAMPLES

### Example 1: Create on-demand health probe config
```
PS C:\>$testProbe =  New-AzApplicationGatewayOnDemandProbe -Protocol "Http" -Path "/" -Timeout 30 -BackendPoolName "pool1" -BackendHttpSettingName "setting1"
```

This command create OnDemandProbe with Protocol as Http, path as "/", backend pool as "pool1" and http setting as "setting1".

### Example 2: Create on-demand health probe config with custom match parameter
```
PS C:\>$responsematch = New-AzApplicationGatewayProbeHealthResponseMatch -Body "helloworld" -StatusCode "200-399","503"
PS C:\>$testProbe =  New-AzApplicationGatewayOnDemandProbe -Protocol "Http" -Path "/" -Timeout 30 -BackendPoolName "pool1" -BackendHttpSettingName "setting1" -match $responsematch
```

This command create OnDemandProbe with Protocol as Http, path as "/", backend pool as "pool1" and http setting as "setting1" and specified match conditions.

## PARAMETERS

### -BackendHttpSettingName
Name of Backend HTTP Setting to use

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendPoolName
Name of Backend Pool to Probe

```yaml
Type: String
Parameter Sets: (All)
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostName
Host name to send probe to

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Match
Body that must be contained in the health response.
Default value is empty

```yaml
Type: PSApplicationGatewayProbeHealthResponseMatch
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Relative path of probe.
Valid path starts from '/'.
Probe is sent to \<Protocol\>://\<host\>:\<port\>\<path\>

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PickHostNameFromBackendHttpSettings
Whether the host header should be picked from the backend http settings.
Default value is false

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Protocol used to send probe

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Http, Https

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeout
Probe timeout in seconds.
Probe marked as failed if valid response is not received with this timeout period

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayOnDemandProbe

## NOTES

## RELATED LINKS
[New-AzApplicationGatewayProbeHealthResponseMatch](./New-AzApplicationGatewayProbeHealthResponseMatch.md)
[Get-AzApplicationGatewayBackendHealthOnDemand](./Get-AzApplicationGatewayBackendHealthOnDemand.md)