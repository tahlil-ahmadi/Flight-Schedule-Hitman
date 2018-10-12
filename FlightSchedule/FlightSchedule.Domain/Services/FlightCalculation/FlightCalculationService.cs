using System;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Domain.Model.Flights;
using Framework.Core;

namespace FlightSchedule.Domain.Services.FlightCalculation
{
    public class FlightCalculationService
    {
        public List<Flight> Calculate(FlightCalculationRequest request)
        {
            var output = new List<Flight>();
            var candidateDays = FindCandidateDays(request);
            foreach (var dateTime in candidateDays)
            {
                var day = request.Timetables.First(a => a.DayOfWeek == dateTime.DayOfWeek);
                var flight = CreateFlight(request, dateTime, day);
                output.Add(flight);
            }
            return output;
        }

        private static List<DateTime> FindCandidateDays(FlightCalculationRequest request)
        {
            return request.From.EachDay(request.To)
                .Where(a => request.Timetables.Select(z => z.DayOfWeek).Contains(a.DayOfWeek))
                .ToList();
        }
        private static Flight CreateFlight(FlightCalculationRequest request, DateTime dateTime, WeeklyTimetable day)
        {
            var route = new Route(request.Origin, request.Destination);
            var departDate = dateTime.Add(day.DepartureTime);
            var arriveDate = dateTime.Add(day.ArrivalTime);
            var flight = new Flight(route, departDate, arriveDate, request.FlightNumber);
            return flight;
        }
    }
}
