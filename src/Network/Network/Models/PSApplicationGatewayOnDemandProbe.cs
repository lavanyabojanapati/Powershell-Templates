using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSApplicationGatewayOnDemandProbe
    {
        public string Protocol { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public int Timeout { get; set; }
        public bool? PickHostNameFromBackendHttpSettings { get; set; }
        public PSApplicationGatewayProbeHealthResponseMatch Match { get; set; }
        public string BackendPoolName { get; set; }
        public string BackendHttpSettingName { get; set; }

        [JsonIgnore]
        public string MatchText
        {
            get { return JsonConvert.SerializeObject(Match, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
