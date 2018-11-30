using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Acceptance.Tests.Hosting;
using TechTalk.SpecFlow;

namespace FlightSchedule.Acceptance.Tests.Hooks
{
    [Binding]
    public static class HostingHook
    {
        private static IISExpressHost host;

        [BeforeTestRun]
        public static void StartHost()
        {
            var projectPath = ConfigurationManager.AppSettings["SUTPath"];
            var port = int.Parse(ConfigurationManager.AppSettings["SUTPort"]);
            host = new IISExpressHost(projectPath, port);
            host.Start();
        }

        [AfterTestRun]
        public static void StopHost()
        {
            host.Stop().Wait();
        }
    }
}
