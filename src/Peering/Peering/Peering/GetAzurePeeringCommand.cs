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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az Peering cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeering", DefaultParameterSetName = Constants.BySubscription)]
    [OutputType(typeof(PSPeering))]
    public class GetAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets the Peering name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.PeeringByResourceAndName)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.PeeringByResourceIpPrefixes)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }

        /// <summary>
        ///     Gets or sets the ResourceGroupName
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.BySubscription)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.PeeringByResourceAndName)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.PeeringByResourceIpPrefixes)]
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.PeeringByResource)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the Kind of Peering
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.KindHelp,
            ParameterSetName = Constants.PeeringByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.KindHelp,
            ParameterSetName = Constants.PeeringByKind)]
        [PSArgumentCompleter(Constants.Direct, Constants.Partner)]
        [ValidateSet(Constants.Direct, Constants.Partner, Constants.Exchange, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public virtual string Kind { get; set; }

        /// <summary>
        ///     Gets or sets Prefixes Switch to expand all prefixes
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Shows all Prefixes",
            ParameterSetName = Constants.PeeringByResourceIpPrefixes)]
        [ValidateNotNullOrEmpty]
        public virtual SwitchParameter Prefixes { get; set; }



        /// <inheritdoc />
        /// <summary>
        ///     Execute Override for powershell cmdlet
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            if (string.Equals(
                this.ParameterSetName,
                Constants.PeeringByResourceAndName,
                StringComparison.OrdinalIgnoreCase))
            {
                var psPeeringions = this.GetPeeringByResourceAndName();
                this.WriteObject(psPeeringions, true);
            }
            else if (string.Equals(
                this.ParameterSetName,
                Constants.PeeringByResource,
                StringComparison.OrdinalIgnoreCase))
            {
                var psPeeringions = this.GetPeeringByResource();
                this.WriteObject(psPeeringions, true);
            }
            else if (this.ParameterSetName.Contains(Constants.PeeringByKind))
            {
                var psPeeringions = this.GetPeeringByKind();
                this.WriteObject(psPeeringions, true);
            }
            else
            {
                var psPeeringions = this.GetPeeringBySubscription();
                this.WriteObject(psPeeringions, true);
            }
        }

        /// <summary>
        ///     Gets Peering by its Kind
        /// </summary>
        /// <returns>List of Peering resources</returns>
        public List<object> GetPeeringByKind()
        {
            var psPeeringions = new List<object>();
            var icList = this.PeeringClient.ListAll();
            foreach (var ic in icList) psPeeringions.Add(this.ToPeeringPs(ic));

            var kindPeering = new List<object>();
            foreach (var psIc in psPeeringions)
                if (icList.FirstOrDefault()?.Kind == this.Kind)
                {
                    kindPeering.Add(psIc);
                }
                else
                {
                    Console.WriteLine(
                        $"No objects are of Kind: '{this.Kind}' with Subscription: {this.EdgeClient.SubscriptionId}");
                    break;
                }

            return kindPeering;
        }

        /// <summary>
        ///     Gets Peering Resource by ResourceGroupName
        /// </summary>
        /// <returns>List of Peering Resources</returns>
        public List<object> GetPeeringByResource()
        {
            var icList = this.PeeringClient.List(this.ResourceGroupName);
            var psPeeringions = new List<object>();
            foreach (var ic in icList) psPeeringions.Add(this.ToPeeringPs(ic));

            if (this.Kind != null)
            {
                var kindPeering = new List<object>();
                foreach (var psIc in psPeeringions)
                    if (icList.FirstOrDefault()?.Kind == this.Kind)
                    {
                        kindPeering.Add(psIc);
                    }
                    else
                    {
                        kindPeering.Add(psIc);
                        Console.WriteLine($"Debugging - No objects are of Kind: {this.Kind} returned all locations");
                    }

                return kindPeering;
            }

            return psPeeringions;
        }

        /// <summary>
        ///     Gets the Peering Resource by ResourceGroupName and Peering Name
        /// </summary>
        /// <returns>Peering Resource</returns>
        public object GetPeeringByResourceAndName()
        {
            var ic = this.PeeringClient.Get(this.ResourceGroupName, this.PeeringName);
            var psLc = this.ToPeeringPs(ic);
            return psLc;
        }

        /// <summary>
        ///     Gets all Peerings for a subscription.
        /// </summary>
        /// <returns>List of all Peerings for a subscription</returns>
        public List<object> GetPeeringBySubscription()
        {
            var icList = this.PeeringClient.ListAll();
            var psPeeringions = new List<object>();
            foreach (var ic in icList) psPeeringions.Add(this.ToPeeringPs(ic));

            return psPeeringions;
        }
    }
}