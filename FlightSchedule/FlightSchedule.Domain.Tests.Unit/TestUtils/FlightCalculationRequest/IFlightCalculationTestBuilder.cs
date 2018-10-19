namespace FlightSchedule.Domain.Tests.Unit.TestUtils
{
    using FlightSchedule.Domain.Services.FlightCalculation;
    using System;
    public interface IFlightCalculationTestBuilder
    {
        IFlightCalculationRequestTestBuilder WithFlightCalculationRequestTestBuilder();
        //IWeeklyTimeTableTestBuilder WithWeeklyTimeTableTestBuilder();
    }

    public interface IBuild
    {
        FlightCalculationRequest Build();
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

    //public interface IWeeklyTimeTableTestBuilder : IBuild
    //{
    //}
}
