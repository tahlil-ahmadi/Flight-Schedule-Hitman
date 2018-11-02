using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Domain.Model.Flights;
using Mapster;

namespace FlightSchedule.Application.Mappings
{
    public static class DtoMapping
    {
        public static void Config()
        {
            TypeAdapterConfig<Flight, FlightDto>
                .ForType()
                .Map(dest => dest.Destination,src => src.Route.Destination)
                .Map(dest => dest.Origin, src => src.Route.Origin);
        }
    }
}
