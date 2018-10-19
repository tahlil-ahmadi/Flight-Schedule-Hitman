using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Domain.Services.FlightCalculation;

namespace FlightSchedule.Application
{
    public class FlightGenerationService
    {
        private readonly IFlightRepository _repository;
        private readonly IFlightCalculationService _calculationService;
        public FlightGenerationService(IFlightRepository repository, IFlightCalculationService calculationService)
        {
            _repository = repository;
            _calculationService = calculationService;
        }
        public void Generate(FlightCalculationRequest request)
        {
            var generatedFlights = _calculationService.Calculate(request);
            foreach (var flight in generatedFlights)
            {
                _repository.Add(flight);
            }
        }
    }
}
