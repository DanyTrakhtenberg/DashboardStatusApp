using DashboardStatusApp.Logic;
using DashboardStatusUnitTest.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DashboardStatusUnitTest
{
    [TestClass]
    public class ClientOnlineTest
    {
        ClientOnline clientOnline;
        MockedCurrentTime mockedCurrentTime;
        
        [TestMethod]
        public void ClientOnlineTest_Offline_LateReceive()
        {
            var clientOnline = new ClientOnline(new MockedCurrentTime(new DateTime(2020, 5, 23, 2, 25, 0)));
            var result = clientOnline.IsClientOnline(new DateTime(2020, 5, 23, 2, 23, 0));
            Assert.AreEqual(result, false);

        }

        [TestMethod]
        public void ClientOnlineTest_Online_SameTimeReceived()
        {
            var clientOnline = new ClientOnline(new MockedCurrentTime(new DateTime(2020, 5, 23, 2, 25, 0)));
            var result = clientOnline.IsClientOnline(new DateTime(2020, 5, 23, 2, 25, 0));
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void ClientOnlineTest_Online_CameInTeFuture()
        {
            var clientOnline = new ClientOnline(new MockedCurrentTime(new DateTime(2020, 5, 23, 2, 25, 0)));
            var result = clientOnline.IsClientOnline(new DateTime(2020, 5, 23, 2, 26, 0));
            Assert.AreEqual(result, true);

        }
    }
}
