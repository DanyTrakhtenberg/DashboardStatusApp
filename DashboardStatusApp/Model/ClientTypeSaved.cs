using DashboardStatusApp.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardStatusApp.Model
{
    public class ClientTypeSaved
    {
        [JsonProperty(PropertyName = "client")]
        public ClientType Client { get; set; }
        [JsonProperty("receivedDate")]
        public DateTime ReceivedDate { get; set; }
    }
}
