using System.Configuration;
using FlightSchedule.Specs.Hosting;
using TechTalk.SpecFlow;

namespace FlightSchedule.Specs.Hooks
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
            host.Stop();
        }
    }
}
