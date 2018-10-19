using System;
using System.Collections.Generic;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Domain.Services.FlightCalculation;
using FlightSchedule.Domain.Tests.Util.TestUtils;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace FlightSchedule.Application.Tests.Unit
{
    public class FlightGenerationServiceTests
    {
        [Fact]
        public void Generate_should_generate_flights_based_on_request_and_save_them()
        {
            #region Using-Mock
            //var repository = Substitute.For<IFlightRepository>();
            //var calculationService = Substitute.For<IFlightCalculationService>();
            //var flights = SomeFlights();
            //calculationService.Calculate(Arg.Any<FlightCalculationRequest>()).Returns(flights);
            //var service = new FlightGenerationService(repository, calculationService);

            //service.Generate(new FlightCalculationRequest());

            //repository.Received(3).Add(Arg.Any<Flight>()); 
            #endregion

            var repository = new FakeFlightRepository();
            var calculationService = Substitute.For<IFlightCalculationService>();
            var flights = SomeFlights();
            calculationService.Calculate(Arg.Any<FlightCalculationRequest>()).Returns(flights);
            var service = new FlightGenerationService(repository, calculationService);

            service.Generate(new FlightCalculationRequest());

            var actualInsertedFlights = repository.GetFlights();
            actualInsertedFlights.Should().BeEquivalentTo(flights);
        }

        private List<Flight> SomeFlights()
        {
            var output = new List<Flight>
            {
                new FlightTestBuilder().Build(),
                new FlightTestBuilder().Build(),
                new FlightTestBuilder().Build(),
            };
            return output;
        }
    }
}
