using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts;
using Framework.Web.Tools.Http;

namespace FlightSchedule.Acceptance.Tests.Tasks
{
    public static class FlightGenerationTask
    {
        public static void Perform(FlightCalculationRequestDto dto)
        {
            HttpRequestBuilder.CreateNew()
                .WithUrl("http://localhost:21000/api/flights")
                .WithPostVerb()
                .WithContentAsJson(dto)
                .DispatchAsync()
                .Wait();
        }
    }
}
