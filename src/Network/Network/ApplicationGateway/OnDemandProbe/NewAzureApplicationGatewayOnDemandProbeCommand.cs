// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayOnDemandProbe"), OutputType(typeof(PSApplicationGatewayOnDemandProbe))]
    public class NewAzureApplicationGatewayOnDemandProbeCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Protocol used to send probe")]
        [ValidateSet("Http", "Https", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Host name to send probe to")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period")]
        [ValidateNotNullOrEmpty]
        public int Timeout { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Whether the host header should be picked from the backend http settings. Default value is false")]
        public SwitchParameter PickHostNameFromBackendHttpSettings { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Body that must be contained in the health response. Default value is empty")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayProbeHealthResponseMatch Match { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of Backend Pool to Probe")]
        [ValidateNotNullOrEmpty]
        public string BackendPoolName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of Backend HTTP Setting to use")]
        [ValidateNotNullOrEmpty]
        public string BackendHttpSettingName { get; set; }

        public PSApplicationGatewayOnDemandProbe NewObject()
        {
            var probe = new PSApplicationGatewayOnDemandProbe();
            probe.Protocol = this.Protocol;
            probe.Host = this.HostName;
            probe.Path = this.Path;
            probe.Timeout = this.Timeout;
            if (this.PickHostNameFromBackendHttpSettings.IsPresent)
            {
                probe.PickHostNameFromBackendHttpSettings = true;
            }
            probe.Match = this.Match;
            probe.BackendPoolName = this.BackendPoolName;
            probe.BackendHttpSettingName = this.BackendHttpSettingName;

            return probe;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(NewObject());
        }
    }
}
