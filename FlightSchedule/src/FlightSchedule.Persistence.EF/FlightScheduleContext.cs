using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model.Flights;
using FlightSchedule.Persistence.EF.Mappings;

namespace FlightSchedule.Persistence.EF
{
    public class FlightScheduleContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public FlightScheduleContext(): base("DBConnection")
        {
            Database.SetInitializer<FlightScheduleContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(RouteMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
