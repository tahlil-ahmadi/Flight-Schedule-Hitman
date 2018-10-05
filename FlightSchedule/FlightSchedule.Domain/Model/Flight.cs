using System;
using FlightSchedule.Domain.Tests.Unit.Model;

namespace FlightSchedule.Domain.Model
{
    public class Flight
    {
        public Route Route { get; private set; }
        public DateTime DepartDate { get;private set; }
        public DateTime ArriveDate { get;private set; }
        public string FlightNumber { get; private set; }

        public Flight(Route route, DateTime departDate, DateTime arriveDate, string flightNumber)
        {
            if (departDate > arriveDate) throw new Exception();

            this.Route = route;
            this.DepartDate = departDate;
            this.ArriveDate = arriveDate;
            this.FlightNumber = flightNumber;
        }

    }
}