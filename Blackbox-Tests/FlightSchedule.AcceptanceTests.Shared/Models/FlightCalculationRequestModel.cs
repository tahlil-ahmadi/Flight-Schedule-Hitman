using System;
using System.Collections.Generic;

namespace FlightSchedule.AcceptanceTests.Shared.Models
{
    public class FlightCalculationRequestModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string FlightNumber { get; set; }
        public List<WeeklyTimetableModel> Timetables { get; set; }
    }
}
