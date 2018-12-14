using FlightSchedule.AcceptanceTests.Shared.Models;

namespace FlightSchedule.AcceptanceTests.Shared.Tasks
{
    public interface IFlightGenerationTask : ITask
    {
        void Perform(FlightCalculationRequestModel model);
    }
}