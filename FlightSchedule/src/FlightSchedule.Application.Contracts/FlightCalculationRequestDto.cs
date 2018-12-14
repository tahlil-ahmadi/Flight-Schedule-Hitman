using System;
using System.Collections.Generic;

namespace FlightSchedule.Application.Contracts
{
    public class FlightCalculationRequestDto
    {
            public string Origin { get; set; }
            public string Destination { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public string FlightNumber { get; set; }
            public List<WeeklyTimetableDto> Timetables { get; set; }
    }
}
