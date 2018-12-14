using System;
using System.Linq;
using FlightSchedule.AcceptanceTests.Shared.Models;
using FlightSchedule.AcceptanceTests.Shared.Questions;
using FlightSchedule.AcceptanceTests.Shared.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FlightSchedule.Specs
{
    [Binding]
    public class FlightGenerationSteps
    {
        private readonly IFlightGenerationTask _task;
        private readonly IFlightQuestion _question;
        private FlightCalculationRequestModel _model;

        public FlightGenerationSteps(IFlightGenerationTask task,
                                     IFlightQuestion question)
        {
            _task = task;
            _question = question;
        }

        [Given(@"I reserved a flight from airline with following information")]
        public void GivenIReservedAFlightFromAirlineWithFollowingInformation(Table table)
        {
            _model = table.CreateInstance<FlightCalculationRequestModel>();
            _model.FlightNumber = Guid.NewGuid().ToString();
        }
        
        [Given(@"The flight has the following weekly timetable")]
        public void GivenTheFlightHasTheFollowingWeeklyTimetable(Table table)
        {
            _model.Timetables = table.CreateSet<WeeklyTimetableModel>().ToList();
        }
        
        [When(@"I generate the flights")]
        public void WhenIGenerateTheFlights()
        {
            _task.Perform(_model);
        }
        
        [Then(@"The following flights should be generated")]
        public void ThenTheFollowingFlightsShouldBeGenerated(Table table)
        {
            var expectedFlights = table.CreateSet<FlightModel>().OrderBy(a=>a.ArriveDate).ToList();
            var actualFlights = _question.Ask(_model.FlightNumber);

            actualFlights.Should().BeEquivalentTo(expectedFlights, options=>options.Excluding(a=>a.Id).Excluding(a=>a.FlightNumber));
        }
    }
}
