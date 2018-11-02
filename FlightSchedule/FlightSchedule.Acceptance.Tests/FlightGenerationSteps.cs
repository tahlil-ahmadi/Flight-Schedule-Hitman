using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using FlightSchedule.Acceptance.Tests.Questions;
using FlightSchedule.Acceptance.Tests.Tasks;
using FlightSchedule.Application.Contracts;
using FluentAssertions;
using Framework.Web.Tools.Http;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FlightSchedule.Acceptance.Tests
{
    [Binding]
    public class FlightGenerationSteps
    {
        //TODO: refactor this class
        private FlightCalculationRequestDto dto;

        [Given(@"I reserved a flight from airline with following information")]
        public void GivenIReservedAFlightFromAirlineWithFollowingInformation(Table table)
        {
            dto = table.CreateInstance<FlightCalculationRequestDto>();
            dto.FlightNumber = Guid.NewGuid().ToString();
        }
        
        [Given(@"The flight has the following weekly timetable")]
        public void GivenTheFlightHasTheFollowingWeeklyTimetable(Table table)
        {
            dto.Timetables = table.CreateSet<WeeklyTimetableDto>().ToList();
        }
        
        [When(@"I generate the flights")]
        public void WhenIGenerateTheFlights()
        {
            FlightGenerationTask.Perform(dto);
        }
        
        [Then(@"The following flights should be generated")]
        public void ThenTheFollowingFlightsShouldBeGenerated(Table table)
        {
            var expectedFlights = table.CreateSet<FlightDto>().OrderBy(a=>a.ArriveDate).ToList();
            var actualFlights = FlightQuestion.Ask(dto.FlightNumber);

            actualFlights.Should().BeEquivalentTo(expectedFlights, options=>options.Excluding(a=>a.Id).Excluding(a=>a.FlightNumber));
        }
    }
}
