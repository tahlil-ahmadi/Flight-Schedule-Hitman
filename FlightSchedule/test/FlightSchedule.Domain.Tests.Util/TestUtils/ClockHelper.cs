using System;

namespace FlightSchedule.Domain.Tests.Util.TestUtils
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
