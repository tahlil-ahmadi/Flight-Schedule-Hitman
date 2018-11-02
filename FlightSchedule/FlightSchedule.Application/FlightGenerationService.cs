using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Domain.Services.FlightCalculation;
using Mapster;

namespace FlightSchedule.Application
{
    public class FlightGenerationService : IFlightGenerationService
    {
        private readonly IFlightRepository _repository;
        private readonly IFlightCalculationService _calculationService;
        public FlightGenerationService(IFlightRepository repository, IFlightCalculationService calculationService)
        {
            _repository = repository;
            _calculationService = calculationService;
        }
        public void Generate(FlightCalculationRequestDto dto)
        {
            var request = dto.Adapt<FlightCalculationRequest>();
            var generatedFlights = _calculationService.Calculate(request);
            foreach (var flight in generatedFlights)
            {
                _repository.Add(flight);
            }
        }

        public List<FlightDto> Get(string flightNumber)
        {
            var flights = _repository.GetByFlightNo(flightNumber);
            return flights.Adapt<List<FlightDto>>();
        }
    }
}
