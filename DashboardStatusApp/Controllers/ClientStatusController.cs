using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DashboardStatusApp.DTO;
using DashboardStatusApp.Logic;
using DashboardStatusApp.Mangers.Interface;
using DashboardStatusApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DashboardStatusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientStatusController : ControllerBase
    {
        
        private IClientStatusManager _clientStatusManager;
        public ClientStatusController(IClientStatusManager mngr)
        {
            _clientStatusManager = mngr;
        }
        // GET: api/ClientStatus
        /// <summary>
        /// Get the status of the client to present the information on a view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ClientStatus> Get()
        {
            return _clientStatusManager.Get();
        }

        // POST: api/ClientStatus
        /// <summary>
        /// Get information from the user and update the cache
        /// </summary>
        /// <param name="clientType"></param>
        [HttpPost]
        public void Post( ClientType clientType)
        {
            _clientStatusManager.Post(clientType);

        }
    }
}
