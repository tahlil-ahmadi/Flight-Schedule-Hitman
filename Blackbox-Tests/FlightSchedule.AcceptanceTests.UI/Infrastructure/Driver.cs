using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FlightSchedule.AcceptanceTests.UI.Infrastructure
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _current;
        public static IWebDriver Current
        {
            get => _current;
            set => _current = value;
        }
    }
}
