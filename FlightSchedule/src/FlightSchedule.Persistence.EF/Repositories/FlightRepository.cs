using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model.Flights;

namespace FlightSchedule.Persistence.EF.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightScheduleContext _context;
        public FlightRepository(FlightScheduleContext context)
        {
            _context = context;
        }
        public void Add(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public List<Flight> GetByFlightNo(string flightNo)
        {
            return _context.Flights.Where(a => a.FlightNumber == flightNo).ToList();
        }

        public Flight GetById(long id)
        {
            return _context.Flights.FirstOrDefault(a => a.Id == id);
        }
    }
}
