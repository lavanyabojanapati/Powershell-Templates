using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSApplicationGatewayBackendHealthOnDemand
    {
        public PSApplicationGatewayBackendAddressPool BackendAddressPool { get; set; }
        public PSApplicationGatewayBackendHealthHttpSettings BackendHealthHttpSettings { get; set; }

        [JsonIgnore]
        public string BackendAddressPoolText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPool, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendHealthHttpSettingsText
        {
            get { return JsonConvert.SerializeObject(BackendHealthHttpSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
