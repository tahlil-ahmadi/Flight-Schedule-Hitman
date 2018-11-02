using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts;
using Framework.Web.Tools.Http;

namespace FlightSchedule.Acceptance.Tests.Questions
{
    public static class FlightQuestion
    {
        public static List<FlightDto> Ask(string flightNo)
        {
            return HttpRequestBuilder.CreateNew()
                .WithUrl($"http://localhost:21000/api/flights?flightNo={flightNo}")
                .WithGetVerb()
                .DispatchAsync<List<FlightDto>>()
                .Result;
        }
    }
}
