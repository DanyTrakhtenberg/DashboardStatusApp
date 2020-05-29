using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardStatusApp.Logic
{
    public class ClientOnline
    {
        ICurrentTime _currentTime;
        public ClientOnline(ICurrentTime currentTime)
        {
            _currentTime = currentTime;
        }
        private readonly double GRASE_PERIOD_MINUTE = 1;
        public bool IsClientOnline(DateTime receivedTime)
        {
            if (_currentTime.GetCurrentTime() <= receivedTime.AddMinutes(GRASE_PERIOD_MINUTE))
            {
                return true;
            }
            return false;
        }
    }
}
