using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using FlightSchedule.AcceptanceTests.Shared.Tasks;

namespace FlightSchedule.Specs.Tools
{
    public class TaskResolver
    {
        private IObjectContainer _container;
        public TaskResolver(IObjectContainer container)
        {
            _container = container;
        }
        public T ResolveTask<T>() where T : ITask
        {
            return _container.Resolve<T>();
        }
    }
}
