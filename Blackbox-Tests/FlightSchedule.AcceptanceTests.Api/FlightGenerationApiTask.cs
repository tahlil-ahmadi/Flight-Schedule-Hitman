using FlightSchedule.AcceptanceTests.Shared.Models;
using FlightSchedule.AcceptanceTests.Shared.Tasks;
using Framework.Web.Tools.Http;

namespace FlightSchedule.AcceptanceTests.Api
{
    public class FlightGenerationApiTask : IFlightGenerationTask
    {
        public void Perform(FlightCalculationRequestModel model)
        {
            HttpRequestBuilder.CreateNew()
                .WithUrl("http://localhost:21000/api/flights")
                .WithPostVerb()
                .WithContentAsJson(model)
                .DispatchAsync()
                .Wait();
        }
    }
}
