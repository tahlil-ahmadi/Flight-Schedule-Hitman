using System.Collections.Generic;
using FlightSchedule.Domain.Model.Flights;

namespace FlightSchedule.Application.Tests.Unit
{
    internal class FakeFlightRepository : IFlightRepository
    {
        private List<Flight> _flights = new List<Flight>();
        public void Add(Flight flight)
        {
            this._flights.Add(flight);
        }
        public List<Flight> GetFlights()
        {
            return _flights;
        }
    }
}