using FlightSchedule.Application.Contracts;

namespace FlightSchedule.Acceptance.Tests.Tasks
{
    public interface IFlightGenerationTask
    {
        void Perform(FlightCalculationRequestDto dto);
    }
}