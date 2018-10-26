using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Model.Flights
{
    public interface IFlightRepository
    {
        void Add(Flight flight);
    }
}
