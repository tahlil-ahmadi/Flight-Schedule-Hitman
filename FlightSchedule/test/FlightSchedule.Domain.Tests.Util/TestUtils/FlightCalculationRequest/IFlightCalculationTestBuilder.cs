using System;
using FlightSchedule.Domain.Services.FlightCalculation;

namespace FlightSchedule.Domain.Tests.Util.TestUtils.FlightCalculationRequest
{
    public interface IFlightCalculationTestBuilder
    {
        IFlightCalculationRequestTestBuilder WithFlightCalculationRequestTestBuilder();
    }

    public interface IBuild
    {
        Services.FlightCalculation.FlightCalculationRequest Build();
    }

    public interface IFlightCalculationRequestTestBuilder : IBuild
    {
        IFlightCalculationRequestTestBuilder WithDestination(string destination);
        IFlightCalculationRequestTestBuilder WithOrigin(string origin);
        IFlightCalculationRequestTestBuilder WithFlightNumber(string flightNumber);
        IFlightCalculationRequestTestBuilder WithFrom(DateTime from);
        IFlightCalculationRequestTestBuilder WithTo(DateTime to);
        IFlightCalculationRequestTestBuilder WithWeeklyTimeTable(WeeklyTimetable timetables);
    }
}
