using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FlightSchedule.Domain.Tests.Util.TestUtils;
using FlightSchedule.Persistence.EF.Repositories;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Persistence.EF.Tests.Integration
{
    public class FlightRepositoryTests : PersistenceTest
    {
        [Fact]
        public void Should_save_flight()
        {
            var flight = new FlightTestBuilder().Build();
            var repository = new FlightRepository(this.DbContext);

            repository.Add(flight);
            ClearChangeTracker();

            var actualFlight = repository.GetById(flight.Id);
            actualFlight.Should().BeEquivalentTo(flight); 
        }
    }
}
