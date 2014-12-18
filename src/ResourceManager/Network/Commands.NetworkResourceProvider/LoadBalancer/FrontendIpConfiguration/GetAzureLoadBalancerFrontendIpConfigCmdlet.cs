﻿// ----------------------------------------------------------------------------------
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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Get, "AzureLoadBalancerFrontendIpConfig"), OutputType(typeof(PSFrontendIpConfiguration))]
    public class GetAzureLoadBalancerFrontendIpConfigCmdlet : NetworkBaseClient
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the FrontendIpConfig")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The loadbalancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            
            if (!string.IsNullOrEmpty(this.Name))
            {
                var frontendIpConfiguration =
                    this.LoadBalancer.Properties.FrontendIpConfigurations.First(
                        resource =>
                            string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                WriteObject(frontendIpConfiguration);
            }
            else
            {
                var frontendIpConfigurations = this.LoadBalancer.Properties.FrontendIpConfigurations;
                WriteObject(frontendIpConfigurations, true);
            }
            
        }
    }
}
