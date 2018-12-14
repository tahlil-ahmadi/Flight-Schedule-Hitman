using System.Collections.Generic;
using FlightSchedule.AcceptanceTests.Shared.Models;

namespace FlightSchedule.AcceptanceTests.Shared.Questions
{
    public interface IFlightQuestion : IQuestion
    {
        List<FlightModel> Ask(string flightNo);
    }
}
