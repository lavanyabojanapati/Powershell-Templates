using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSApplicationGatewayOnDemandProbe
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Protocol { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Host { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Path { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public int Timeout { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? PickHostNameFromBackendHttpSettings { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string BackendPoolName { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string BackendHttpSettingName { get; set; }
        public PSApplicationGatewayProbeHealthResponseMatch Match { get; set; }

        [JsonIgnore]
        public string MatchText
        {
            get { return JsonConvert.SerializeObject(Match, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
