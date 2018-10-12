using System;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Domain.Tests.Unit.TestUtils;
using FluentAssertions;
using Xunit;
using Exception = System.Exception;

namespace FlightSchedule.Domain.Tests.Unit.Model
{
    public class FlightTests
    {
        private readonly FlightTestBuilder _flightBuilder;
        public FlightTests()
        {
            this._flightBuilder = new FlightTestBuilder();
        }

        [Fact]
        public void Constructor_should_create_flight_properly()
        {
            var flight = _flightBuilder.Build();

            flight.Route.Origin.Should().Be(_flightBuilder.Origin);
            flight.Route.Destination.Should().Be(_flightBuilder.Destination);
            flight.DepartDate.Should().Be(_flightBuilder.DepartDate);
            flight.ArriveDate.Should().Be(_flightBuilder.ArriveDate);
            flight.FlightNumber.Should().Be(_flightBuilder.FlightNumber);
        }

        [Theory]
        [InlineData("IKA","IKA")]
        [InlineData("IKA", "ika")]
        [InlineData("ika", "IKA")]
        [InlineData("ika", "ika")]
        public void Constructor_should_throw_when_origin_and_destination_are_same(string origin, string destination)
        {
            var builder = _flightBuilder
                                .WithOrigin(origin)
                                .WithDestination(destination);

            Action constructor = ()=> builder.Build();

            constructor.Should().Throw<InvalidRouteException>();
        }

        [Fact]
        public void Constructor_should_throw_when_depart_date_is_after_arrive_date()
        {
            var departDate = ClockHelper.SomeDate();
            var arriveDate = ClockHelper.SomeDateBefore(departDate);

            var builder = _flightBuilder
                .WithDepartDate(departDate)
                .WithArriveDate(arriveDate);

            Action constructor = () => builder.Build();

            constructor.Should().Throw<Exception>();
        }
    }
}
