using System.Data.Entity.ModelConfiguration;
using FlightSchedule.Domain.Model.Flights;

namespace FlightSchedule.Persistence.EF.Mappings
{
    public class RouteMapping : ComplexTypeConfiguration<Route>
    {
        public RouteMapping()
        {
            Property(a => a.Destination).HasColumnName("Destination").IsRequired();
            Property(a => a.Origin).HasColumnName("Origin").IsRequired();
        }
    }
}