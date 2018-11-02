using System;

namespace FlightSchedule.Application.Contracts
{
    public class WeeklyTimetableDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}