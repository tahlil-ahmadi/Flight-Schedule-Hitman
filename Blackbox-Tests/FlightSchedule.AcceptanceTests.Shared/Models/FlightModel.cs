using System;

namespace FlightSchedule.AcceptanceTests.Shared.Models
{
    public class FlightModel
    {
        public long Id { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime ArriveDate { get; set; }
        public string FlightNumber { get; set; }
    }
}
