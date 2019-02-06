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
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Remove Peering cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzPeering")]
    [OutputType(typeof(PSPeering))]
    public class RemoveAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     The Peering name.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }

        /// <summary>
        ///     The ResourceGroupName
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Force the execution of the command.
        /// </summary>
        [Parameter]
        public virtual SwitchParameter Force { get; set; }

        /// <summary>
        ///     Execute Override for powershell cmdlet
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.ConfirmAction(
                this.Force,
                Constants.ContinueMessage,
                Constants.ProcessMessage,
                this.PeeringName,
                this.RemovePeering);
        }

        /// <summary>
        ///     Removes the Peering Resource.
        /// </summary>
        /// <returns></returns>
        public void RemovePeering()
        {
            this.PeeringClient.Delete(this.ResourceGroupName, this.PeeringName);
            this.WriteObject($"Peering {this.PeeringName} Resource Removed.");
        }
    }
}