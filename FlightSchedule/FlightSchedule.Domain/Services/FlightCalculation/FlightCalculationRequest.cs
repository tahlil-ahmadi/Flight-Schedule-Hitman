using System;
using System.Collections.Generic;

namespace FlightSchedule.Domain.Services.FlightCalculation
{
    public class FlightCalculationRequest
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string FlightNumber { get; set; }
        public List<WeeklyTimetable> Timetables { get; set; }
    }
}
