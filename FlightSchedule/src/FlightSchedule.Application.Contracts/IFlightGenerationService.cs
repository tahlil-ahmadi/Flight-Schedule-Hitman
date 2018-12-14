using System.Collections.Generic;

namespace FlightSchedule.Application.Contracts
{
    public interface IFlightGenerationService
    {
        void Generate(FlightCalculationRequestDto dto);
        List<FlightDto> Get(string flightNumber);
    }
}