using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardStatusApp.DTO
{
    public class ClientStatus
    {
        [JsonProperty(PropertyName = "clientType")]

        public ClientType ClientType { get; set; }
        [JsonProperty(PropertyName = "isOnline")]

        public bool IsOnline { get; set; }

        public ClientStatus(ClientType clientType, bool isOnline)
        {
            ClientType = clientType;
            IsOnline = isOnline;
        }
    }
}
