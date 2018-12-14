using System;

namespace FlightSchedule.Domain.Model.Flights
{
    public class Flight
    {
        public long Id { get; private set; }
        public Route Route { get; private set; }
        public DateTime DepartDate { get;private set; }
        public DateTime ArriveDate { get;private set; }
        public string FlightNumber { get; private set; }
        protected Flight(){}
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