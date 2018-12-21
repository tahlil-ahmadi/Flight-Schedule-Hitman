using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.AcceptanceTests.UI.Infrastructure;
using OpenQA.Selenium;

namespace FlightSchedule.AcceptanceTests.UI.Framework
{
    public static class Dropdown
    {
        public static void Choose(By selector, Enum value)
        {
            Driver.Current.FindElement(selector).SendKeys(value.ToString());
        }
    }
}
