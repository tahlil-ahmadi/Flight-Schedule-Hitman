using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Tests.Unit.TestUtils
{
    public static class ClockHelper
    {
        public static DateTime SomeDate()
        {
            return DateTime.Now.AddDays(1);
        }

        public static DateTime SomeDateBefore(DateTime date)
        {
            return date.AddDays(-1);
        }
    }
}
