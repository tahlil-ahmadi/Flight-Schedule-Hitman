using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Domain.Services.FlightCalculation;
using FlightSchedule.Domain.Tests.Unit.TestUtils;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Domain.Tests.Unit.Model
{
    public class FlightCalculationTests
    {
        private readonly FlightTestBuilder _flightBuilder;
        private readonly TimeSpan _nine;
        private readonly TimeSpan _tenThirty;
        private readonly TimeSpan _twentyThirty;
        private readonly TimeSpan _twentyTwo;
        public FlightCalculationTests()
        {
            this._flightBuilder = new FlightTestBuilder();
            this._nine = new TimeSpan(9, 0, 0);
            this._tenThirty = new TimeSpan(10, 30, 0);
            this._twentyThirty = new TimeSpan(20, 30, 0);
            this._twentyTwo = new TimeSpan(22, 00, 0);
        }

        [Fact]
        public void Calculate_should_calculate_flights_based_on_days_in_date_period()
        {
            var request = FlightCalculationTestBuilder.New()
                .WithFlightCalculationRequestTestBuilder()
                    .WithDestination("DXB")
                    .WithOrigin("IKA")
                    .WithFlightNumber("WS-20")
                    .WithFrom(CreateDateTime(2018, 09, 30))
                    .WithTo(CreateDateTime(2018, 10, 15))
                    .WithWeeklyTimeTable(CreateWeeklyTimetable(DayOfWeek.Monday, _nine, _tenThirty))
                    .WithWeeklyTimeTable(CreateWeeklyTimetable(DayOfWeek.Wednesday, _twentyThirty, _twentyTwo))
                    .Build();



            var flightBuilder = new FlightTestBuilder()
                .WithFlightNumber("WS-20")
                .WithOrigin("IKA")
                .WithDestination("DXB");

            var expectedFlights = new List<Flight>()
            {
                CreateFlightForMonday(1),
                CreateFlightForWednesday(3),
                CreateFlightForMonday(8),
                CreateFlightForWednesday(10),
                CreateFlightForMonday(15),
            };

            var sut = new FlightCalculationService();
            var calculatedFlights = sut.Calculate(request);

            calculatedFlights.Should().BeEquivalentTo(expectedFlights);
        }

        private Flight CreateFlightForMonday(int day)
        {
            return this._flightBuilder
                .WithDepartDate(new DateTime(2018, 10, day, _nine.Hours, _nine.Minutes, 0))
                .WithArriveDate(new DateTime(2018, 10, day, _tenThirty.Hours, _tenThirty.Minutes, 0))
                .Build();
        }
        private Flight CreateFlightForWednesday(int day)
        {
            return this._flightBuilder
                .WithDepartDate(new DateTime(2018, 10, day, _twentyThirty.Hours, _twentyThirty.Minutes, 0))
                .WithArriveDate(new DateTime(2018, 10, day, _twentyTwo.Hours, _twentyTwo.Minutes, 0))
                .Build();
        }
        private WeeklyTimetable CreateWeeklyTimetable(DayOfWeek dayOfWeek, TimeSpan departureTime, TimeSpan arrivalTime)
        {
            return new WeeklyTimetable()
            {
                DayOfWeek = dayOfWeek,
                ArrivalTime = arrivalTime,
                DepartureTime = departureTime
            };

        }
        private DateTime CreateDateTime(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }
    }
}
