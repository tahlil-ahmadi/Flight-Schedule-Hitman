using BoDi;
using FlightSchedule.AcceptanceTests.Api;
using FlightSchedule.AcceptanceTests.Shared.Questions;
using FlightSchedule.AcceptanceTests.Shared.Tasks;
using TechTalk.SpecFlow;

namespace FlightSchedule.AcceptanceTests.UI.Hooks
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
            _container.RegisterTypeAs<FlightGenerationUiTask, IFlightGenerationTask>();
            _container.RegisterTypeAs<FlightQuestion, IFlightQuestion>();
        }
    }
}
