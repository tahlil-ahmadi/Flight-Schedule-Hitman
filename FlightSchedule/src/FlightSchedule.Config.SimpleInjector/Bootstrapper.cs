using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Application.Mappings;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Domain.Services.FlightCalculation;
using FlightSchedule.Persistence.EF;
using FlightSchedule.Persistence.EF.Repositories;
using SimpleInjector;

namespace FlightSchedule.Config.SimpleInjector
{
    public static class Bootstrapper
    {
        public static void WireUp(Container container)
        {
            DtoMapping.Config();

            container.Register<IFlightRepository, FlightRepository>(Lifestyle.Scoped);
            container.Register<IFlightCalculationService, FlightCalculationService>(Lifestyle.Singleton);
            container.Register<IFlightGenerationService, FlightGenerationService>(Lifestyle.Scoped);
            container.Register<FlightScheduleContext>(Lifestyle.Scoped);
        }
    }
}
