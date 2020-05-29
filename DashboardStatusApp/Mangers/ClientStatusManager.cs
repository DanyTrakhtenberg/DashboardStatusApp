using DashboardStatusApp.DTO;
using DashboardStatusApp.Logic;
using DashboardStatusApp.Mangers.Interface;
using DashboardStatusApp.Model;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardStatusApp.Mangers
{
    public class ClientStatusManager : IClientStatusManager
    {

        private readonly IDistributedCache _distributedCache;
        private readonly int NUMBER_OF_IPS_TO_TRACK = 6;
        private readonly string CACHE_KEY = "IPhash";
        ClientOnline _clientOnline;

        public ClientStatusManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _clientOnline = new ClientOnline(new CurrentTime());    
        }

        public IEnumerable<ClientStatus> Get()
        {
            var ipClientHashStr = _distributedCache.GetString(CACHE_KEY);
            if (string.IsNullOrEmpty(ipClientHashStr) == true)
            {
                return new ClientStatus[0];
            }
            else
            {
                var ipClientHash = JsonConvert.DeserializeObject<Dictionary<string, ClientTypeSaved>>(ipClientHashStr);
                return ipClientHash.Values.Select(ClientReceived => new ClientStatus(ClientReceived.Client, _clientOnline.IsClientOnline(ClientReceived.ReceivedDate)));
            }
        }

        public void Post(ClientType clientType)
        {
            var ipClientHashStr = _distributedCache.GetString(CACHE_KEY);
            if (string.IsNullOrEmpty(ipClientHashStr) == true)
            {
                UpdateNewHash(clientType);
            }
            else
            {
                UpdateExistingHash(clientType, ipClientHashStr);
            }
        }
        private void UpdateExistingHash(ClientType clientType, string ipClientHashStr)
        {
            var ipClientHash = JsonConvert.DeserializeObject<Dictionary<string, ClientTypeSaved>>(ipClientHashStr);
            if (ipClientHash.Count < NUMBER_OF_IPS_TO_TRACK)
            {
                ipClientHash[clientType.IP] = new ClientTypeSaved() { Client = clientType, ReceivedDate = DateTime.Now };
                var serializedHash = JsonConvert.SerializeObject(ipClientHash);
                _distributedCache.SetString("IPhash", serializedHash);
            }
        }

        private void UpdateNewHash(ClientType clientType)
        {
            Dictionary<string, ClientTypeSaved> ipClientTypeHash = new Dictionary<string, ClientTypeSaved>();
            ClientTypeSaved clientTypeReceived = new ClientTypeSaved() { Client = clientType, ReceivedDate = DateTime.Now };
            ipClientTypeHash[clientType.IP] = clientTypeReceived;
            var serializedHash = JsonConvert.SerializeObject(ipClientTypeHash);
            _distributedCache.SetString("IPhash", serializedHash);
        }
    }
}
