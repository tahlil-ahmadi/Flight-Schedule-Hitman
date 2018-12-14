using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model.Flights;

namespace FlightSchedule.Persistence.EF.Mappings
{
    public class FlightMapping : EntityTypeConfiguration<Flight>
    {
        public FlightMapping()
        {
            ToTable("Flights").HasKey(a=>a.Id);
            Property(a => a.DepartDate).IsRequired();
            Property(a => a.ArriveDate).IsRequired();
            Property(a => a.FlightNumber).HasMaxLength(50);
        }
    }
}
