using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FlightSchedule.AcceptanceTests.UI.Infrastructure
{
    public static class DriverExtensions
    {
        public static void WaitUntilElementIsVisible(this IWebDriver driver, By selector)
        {
            Thread.Sleep(20);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(selector));
        }
    }
}
