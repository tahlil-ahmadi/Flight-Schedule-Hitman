using System.Collections.Generic;
using FlightSchedule.Domain.Model.Flights;

namespace FlightSchedule.Domain.Services.FlightCalculation
{
    public interface IFlightCalculationService
    {
        List<Flight> Calculate(FlightCalculationRequest request);
    }
}