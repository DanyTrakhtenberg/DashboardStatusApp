using DashboardStatusApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardStatusApp.Mangers.Interface
{
    public interface IClientStatusManager
    {
        IEnumerable<ClientStatus> Get();
        public void Post(ClientType clientType);

    }
}
