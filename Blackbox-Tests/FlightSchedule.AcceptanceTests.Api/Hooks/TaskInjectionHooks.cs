using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using FlightSchedule.AcceptanceTests.Shared.Questions;
using FlightSchedule.AcceptanceTests.Shared.Tasks;
using TechTalk.SpecFlow;

namespace FlightSchedule.AcceptanceTests.Api.Hooks
{
    [Binding]
    public class TaskInjectionHooks
    {
        private readonly IObjectContainer _container;
        public TaskInjectionHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void SetupTaskInjection()
        {
            _container.RegisterTypeAs<FlightGenerationApiTask, IFlightGenerationTask>();
            _container.RegisterTypeAs<FlightQuestion, IFlightQuestion>();
        }
    }
}
