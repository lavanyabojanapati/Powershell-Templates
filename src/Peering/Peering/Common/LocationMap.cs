using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Common
{
    public class LocationMap
    {
        public string AzureRegion { get; set; }

        public string EdgeSite { get; set; }

        private Dictionary<string, string> LocationDictionary { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMap"/> class. 
        /// Constructor
        /// </summary>
        public LocationMap()
        {
            this.LocationDictionary.Add(this.EdgeSite, this.AzureRegion);
        }

    }
}
