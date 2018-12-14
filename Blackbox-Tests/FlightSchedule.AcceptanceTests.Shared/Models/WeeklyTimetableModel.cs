using System;

namespace FlightSchedule.AcceptanceTests.Shared.Models
{
    public class WeeklyTimetableModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}