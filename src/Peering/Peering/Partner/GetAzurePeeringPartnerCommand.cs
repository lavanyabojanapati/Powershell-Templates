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
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models;
    using Microsoft.Azure.Management.Peering;

    /// <inheritdoc />
    /// <summary>
    ///     Gets the AzureRm Peering Carriers.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmPeeringPartner")]
    [OutputType(typeof(PSPeeringPartner))]
    public class GetAzurePeeringServiceCommand : PeeringBaseCmdlet
    {
        /// <inheritdoc />
        /// <summary>
        ///     Base execute command
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var carrier = this.GetPeeringByCarrier();
            this.WriteObject(carrier, true);
        }

        /// <summary>
        ///     The get Peering by carrier.
        /// </summary>
        /// <returns>
        ///     The <see cref="object" />.
        /// </returns>
        private object GetPeeringByCarrier()
        {
            var icList = this.PeeringServiceClient.List();
            var carrier = new List<object>();
            foreach (var ic in icList)
            {
                var psLc = this.ToPSPeeringPartner(ic);
                carrier.Add(psLc);
            }

            return carrier;
        }
    }
}