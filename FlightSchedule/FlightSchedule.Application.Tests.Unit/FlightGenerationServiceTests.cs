using System;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Application.Mappings;
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
        public FlightGenerationServiceTests()
        {
            DtoMapping.Config();
        }

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

            service.Generate(new FlightCalculationRequestDto());

            var actualInsertedFlights = repository.GetFlights();
            actualInsertedFlights.Should().BeEquivalentTo(flights);
        }

        [Fact]
        public void Get_should_return_flights_based_on_flight_number()
        {
            var repository = new FakeFlightRepository();
            var flight = new FlightTestBuilder().Build();
            repository.Add(flight);
            var expectedFlight = new FlightDto()
            {
                FlightNumber = flight.FlightNumber,
                Destination = flight.Route.Destination,
                DepartDate = flight.DepartDate,
                ArriveDate = flight.ArriveDate,
                Id = flight.Id,
                Origin = flight.Route.Origin
            };
            var service = new FlightGenerationService(repository,null);

            var actualFlights = service.Get(flight.FlightNumber);

            actualFlights.Count.Should().Be(1);
            actualFlights.Should().AllBeEquivalentTo(expectedFlight);
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
