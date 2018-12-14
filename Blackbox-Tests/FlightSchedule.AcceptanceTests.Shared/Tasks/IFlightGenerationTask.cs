using FlightSchedule.AcceptanceTests.Shared.Models;

namespace FlightSchedule.AcceptanceTests.Shared.Tasks
{
    public interface IFlightGenerationTask
    {
        void Perform(FlightCalculationRequestModel dto);
    }
}