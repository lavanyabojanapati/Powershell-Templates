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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;

    /// <summary>
    ///     The get Peering locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeeringServiceProvider")]
    [OutputType(typeof(PSPeeringLocation))]
    public class GetAzurePeeringServiceProviderCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionPeeringName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringLocation { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute method.
        /// </summary>
        public override void Execute()
        {
            try
            {
                base.Execute();
                var PSPeeringPartner = this.GetPeeringServiceProvider();
                this.WriteObject(PSPeeringPartner, true);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.GetBaseException().Message);
            }

        }

        /// <summary>
        ///     Gets the Peering location.
        /// </summary>
        /// <returns>List of Peering locations.</returns>
        public object GetPeeringServiceProvider()
        {
            var icList = this.PeeringServiceClient.List(this.PeeringLocation);
            var listPeeringServiceProvider = icList.Select(this.ToPSPeeringPartner).ToList();
            return listPeeringServiceProvider;
        }
    }
}