using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardStatusApp.DTO
{
    public class ClientType
    {
        [JsonProperty(PropertyName = "ip")]
        public string IP { get; set; }
        [JsonProperty(PropertyName = "localTime")]

        public string LocalTime { get; set; }
        [JsonProperty(PropertyName = "timeZone")]

        public string TimeZone { get; set; }
        [JsonProperty(PropertyName = "browser")]

        public string Browser { get; set; }
        [JsonProperty(PropertyName = "resolution")]

        public string Resolution { get; set; }
    }
}
