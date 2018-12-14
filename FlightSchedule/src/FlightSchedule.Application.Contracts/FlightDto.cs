using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Application.Contracts
{
    public class FlightDto
    {
        public long Id { get;  set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public DateTime DepartDate { get;  set; }
        public DateTime ArriveDate { get;  set; }
        public string FlightNumber { get;  set; }
    }
}
