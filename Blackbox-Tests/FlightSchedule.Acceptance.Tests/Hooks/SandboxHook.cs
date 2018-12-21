using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FlightSchedule.Specs.Hooks
{
    [Binding]
    public class SandboxHook
    {
        private readonly string _dbname;
        private readonly ScenarioContext _context;
        public SandboxHook(ScenarioContext context)
        {
            _context = context;
            _dbname = $"FlightSchedule-{Guid.NewGuid()}";
        }

        [BeforeScenario("Sandbox")]
        public void SetupDatabase()
        {
            //1. Create database
            //2. migrate database
            _context.Add("SANDBOX_DB_NAME", _dbname);
        }

        [AfterScenario("Sandbox")]
        public void DropDatabase()
        {
            //3. drop database !
        }
    }
}
