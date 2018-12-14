using System;
using BoDi;
using FlightSchedule.AcceptanceTests.Shared.Questions;
using FlightSchedule.AcceptanceTests.Shared.Tasks;

namespace FlightSchedule.Specs.Tools
{
    public class QuestionResolver
    {
        private IObjectContainer _container;
        public QuestionResolver(IObjectContainer container)
        {
            _container = container;
        }

        public T ResolveQuestion<T>() where T : IQuestion
        {
            return _container.Resolve<T>();
        }
    }
}