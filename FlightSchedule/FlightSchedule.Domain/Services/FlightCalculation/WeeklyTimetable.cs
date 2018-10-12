using System;

namespace FlightSchedule.Domain.Services.FlightCalculation
{
    public class WeeklyTimetable
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}