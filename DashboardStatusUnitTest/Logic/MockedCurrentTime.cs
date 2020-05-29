using DashboardStatusApp.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardStatusUnitTest.Logic
{
    public class MockedCurrentTime : ICurrentTime
    {
        private DateTime _currentDateTime;
        public MockedCurrentTime(DateTime dateTime)
        {
            _currentDateTime = dateTime;
        }
        public DateTime GetCurrentTime()
        {
            return _currentDateTime;
        }
    }
}
