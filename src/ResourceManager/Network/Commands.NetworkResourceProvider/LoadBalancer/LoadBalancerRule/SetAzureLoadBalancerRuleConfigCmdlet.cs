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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, "AzureLoadBalancerRuleConfig"), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerRuleConfigCmdlet : CommonAzureLoadBalancerRuleConfig
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer rule")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var loadBalancingRule = this.LoadBalancer.Properties.LoadBalancingRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (loadBalancingRule == null)
            {
                throw new ArgumentException("LoadBalancingRule with the specified name does not exist");
            }

            loadBalancingRule.Name = this.Name;
            loadBalancingRule.Properties = new PSLoadBalancingRuleProperties();
            loadBalancingRule.Properties.Protocol = this.Protocol;
            loadBalancingRule.Properties.FrontendPort = this.FrontendPort;
            loadBalancingRule.Properties.BackendPort = this.BackendPort;
            if (this.IdleTimeoutInMinutes > 0)
            {
                loadBalancingRule.Properties.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }
            loadBalancingRule.Properties.EnableFloatingIP = this.EnableFloatingIP.IsPresent;
            loadBalancingRule.Properties.BackendAddressPool = new PSResourceId();
            loadBalancingRule.Properties.BackendAddressPool.Id = this.BackendAddressPoolId;
            loadBalancingRule.Properties.Probe = new PSResourceId();
            loadBalancingRule.Properties.Probe.Id = this.ProbeId;

            loadBalancingRule.Properties.FrontendIPConfigurations = new List<PSResourceId>();

            foreach (var frontendIPConfigurationId in this.FrontendIPConfigurationId)
            {
                var resourceId = new PSResourceId();
                resourceId.Id = frontendIPConfigurationId;
                loadBalancingRule.Properties.FrontendIPConfigurations.Add(resourceId);
            }

            WriteObject(this.LoadBalancer);
        }
    }
}
