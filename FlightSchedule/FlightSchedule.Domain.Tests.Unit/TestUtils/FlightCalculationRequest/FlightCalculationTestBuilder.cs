namespace FlightSchedule.Domain.Tests.Unit.TestUtils
{
    using System;
    using System.Collections.Generic;
    using FlightSchedule.Domain.Services.FlightCalculation;

    public class FlightCalculationTestBuilder : IFlightCalculationTestBuilder, IFlightCalculationRequestTestBuilder
    {
        private string _destination;
        private string _origin;
        private string _flightNumber;
        private DateTime _from;
        private DateTime _to;
        private List<WeeklyTimetable> _timetables;

        private FlightCalculationTestBuilder()
        {
            _destination = "DXB";
            _origin = "IKA";
            _flightNumber = "WS-20";
            _from = DateTime.Now.AddDays(1);
            _to = DateTime.Now.AddDays(15);
            _timetables = new List<WeeklyTimetable>();
        }

        public static IFlightCalculationTestBuilder New()
        {
            return new FlightCalculationTestBuilder();
        }
        public IFlightCalculationRequestTestBuilder WithFlightCalculationRequestTestBuilder()
        {
            return this;
        }
        public IFlightCalculationRequestTestBuilder WithDestination(string destination)
        {
            _destination = destination;
            return this;
        }

        public IFlightCalculationRequestTestBuilder WithFlightNumber(string flightNumber)
        {
            _flightNumber = flightNumber;
            return this;
        }

        public IFlightCalculationRequestTestBuilder WithFrom(DateTime from)
        {
            _from = from;
            return this;
        }

        public IFlightCalculationRequestTestBuilder WithOrigin(string origin)
        {
            _origin = origin;
            return this;
        }

        public IFlightCalculationRequestTestBuilder WithTo(DateTime to)
        {
            _to = to;
            return this;
        }

        public IFlightCalculationRequestTestBuilder WithWeeklyTimeTable(WeeklyTimetable timetables)
        {
            if (timetables != null)
            {
                _timetables.Add(timetables);
            }
            return this;
        }

        public FlightCalculationRequest Build()
        {
            return new FlightCalculationRequest()
            {
                Destination = _destination,
                FlightNumber = _flightNumber,
                From = _from,
                Origin = _origin,
                To = _to,
                Timetables = _timetables
            };
        }


    }
}
