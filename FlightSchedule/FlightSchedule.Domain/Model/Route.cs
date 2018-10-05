using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Tests.Unit.Model;

namespace FlightSchedule.Domain.Model
{
    public class Route
    {
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public Route(string origin, string destination)
        {
            origin = origin.ToUpper();
            destination = destination.ToUpper();
            if (origin.Equals(destination)) throw new InvalidRouteException();

            Origin = origin;
            Destination = destination;
        }
    }
}
