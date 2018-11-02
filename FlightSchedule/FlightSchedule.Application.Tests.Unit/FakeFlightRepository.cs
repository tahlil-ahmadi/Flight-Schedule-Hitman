using System.Collections.Generic;
using System.Linq;
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

        public List<Flight> GetByFlightNo(string flightNo)
        {
            return _flights.Where(a => a.FlightNumber == flightNo).ToList();
        }

        public List<Flight> GetFlights()
        {
            return _flights;
        }
    }
}