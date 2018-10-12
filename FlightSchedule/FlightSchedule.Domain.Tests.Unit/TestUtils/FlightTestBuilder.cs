using System;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Model.Flights;

namespace FlightSchedule.Domain.Tests.Unit.TestUtils
{
    internal class FlightTestBuilder
    {
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public DateTime DepartDate { get; private set; }
        public DateTime ArriveDate {get; private set; }
        public string FlightNumber {get; private set; }

        public FlightTestBuilder()
        {
            this.Origin = "IKA";
            this.Destination = "DXB";
            this.DepartDate = DateTime.Now.AddDays(1);
            this.ArriveDate = DateTime.Now.AddDays(2);
            this.FlightNumber = "WS-20";
        }
        public FlightTestBuilder WithOrigin(string origin)
        {
            this.Origin = origin;
            return this;
        }

        public FlightTestBuilder WithDestination(string destination)
        {
            this.Destination = destination;
            return this;
        }
        public FlightTestBuilder WithDepartDate(DateTime date)
        {
            this.DepartDate = date;
            return this;
        }
        public FlightTestBuilder WithArriveDate(DateTime date)
        {
            this.ArriveDate = date;
            return this;
        }
        public FlightTestBuilder WithFlightNumber(string flightNo)
        {
            this.FlightNumber = flightNo;
            return this;
        }

        public Flight Build()
        {
            var route = new Route(this.Origin, this.Destination);
            return new Flight(route, this.DepartDate,
                this.ArriveDate, this.FlightNumber);
        }
    }
}
