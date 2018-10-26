using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FlightSchedule.Persistence.EF.Tests.Integration
{
    public abstract class PersistenceTest : IDisposable
    {
        private TransactionScope scope;
        public FlightScheduleContext DbContext { get; private set; }
        protected PersistenceTest()
        {
            scope = new TransactionScope();
            this.DbContext = new FlightScheduleContext();
        }
        public void Dispose()
        {
            DbContext.Dispose();
            scope.Dispose();
        }

        public void ClearChangeTracker()
        {
            var entries = DbContext.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                DbContext.Entry(entry.Entity).State = EntityState.Detached;
            }
        }
    }
}
