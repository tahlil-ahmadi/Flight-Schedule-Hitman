using System;
using TechTalk.SpecFlow;

namespace FlightSchedule.Acceptance.Tests
{
    [Binding]
    public class FlightGenerationSteps
    {
        [Given(@"I reserved a flight from airline with following information")]
        public void GivenIReservedAFlightFromAirlineWithFollowingInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The flight has the following weekly timetable")]
        public void GivenTheFlightHasTheFollowingWeeklyTimetable(Table table)
        {
        }
        
        [When(@"I generate the flights")]
        public void WhenIGenerateTheFlights()
        {
        }
        
        [Then(@"The following flights should be generated")]
        public void ThenTheFollowingFlightsShouldBeGenerated(Table table)
        {
        }
    }
}
