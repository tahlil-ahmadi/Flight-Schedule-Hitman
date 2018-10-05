using System;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Tests.Unit.TestUtils;
using FluentAssertions;
using Xunit;
using Exception = System.Exception;

namespace FlightSchedule.Domain.Tests.Unit.Model
{
    public class FlightTests
    {
        [Fact]
        public void Constructor_should_create_flight_properly()
        {
            var builder = new FlightTestBuilder();

            var flight = builder.Build();

            flight.Route.Origin.Should().Be(builder.Origin);
            flight.Route.Destination.Should().Be(builder.Destination);
            flight.DepartDate.Should().Be(builder.DepartDate);
            flight.ArriveDate.Should().Be(builder.ArriveDate);
            flight.FlightNumber.Should().Be(builder.FlightNumber);
        }

        [Theory]
        [InlineData("IKA","IKA")]
        [InlineData("IKA", "ika")]
        [InlineData("ika", "IKA")]
        [InlineData("ika", "ika")]
        public void Constructor_should_throw_when_origin_and_destination_are_same(string origin, string destination)
        {
            var builder = new FlightTestBuilder()
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

            var builder = new FlightTestBuilder()
                .WithDepartDate(departDate)
                .WithArriveDate(arriveDate);

            Action constructor = () => builder.Build();

            constructor.Should().Throw<Exception>();
        }
    }
}
