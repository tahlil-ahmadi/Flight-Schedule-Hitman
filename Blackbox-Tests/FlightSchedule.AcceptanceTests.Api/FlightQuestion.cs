using System.Collections.Generic;
using FlightSchedule.AcceptanceTests.Shared.Models;
using FlightSchedule.AcceptanceTests.Shared.Questions;
using Framework.Web.Tools.Http;

namespace FlightSchedule.AcceptanceTests.Api
{
    public class FlightQuestion : IFlightQuestion
    {
        public List<FlightModel> Ask(string flightNo)
        {
            return HttpRequestBuilder.CreateNew()
                .WithUrl($"http://localhost:21000/api/flights?flightNo={flightNo}")
                .WithGetVerb()
                .DispatchAsync<List<FlightModel>>()
                .Result;
        }
    }
}
