using System;
using System.Threading;
using FlightSchedule.AcceptanceTests.Shared.Models;
using FlightSchedule.AcceptanceTests.Shared.Tasks;
using FlightSchedule.AcceptanceTests.UI.Framework;
using FlightSchedule.AcceptanceTests.UI.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FlightSchedule.AcceptanceTests.UI
{
    public class FlightGenerationUiTask : IFlightGenerationTask
    {
        public void Perform(FlightCalculationRequestModel model)
        {
            Driver.Current.Navigate().GoToUrl("http://localhost:4200");
            Driver.Current.FindElement(By.Id("originInput")).SendKeys(model.Origin);
            Driver.Current.FindElement(By.Id("destinationInput")).SendKeys(model.Destination);
            Driver.Current.FindElement(By.Id("fromDateInput")).SendKeys(model.From.ToShortDateString());
            Driver.Current.FindElement(By.Id("toDateInput")).SendKeys(model.To.ToShortDateString());
            Driver.Current.FindElement(By.Id("flightNumberInput")).SendKeys(model.FlightNumber);

            foreach (var timetable in model.Timetables)
            {
                Driver.Current.FindElement(By.Id("addTimetableItem")).Click();
                //also a bad practice (going into ui details)
                Dropdown.Choose(By.CssSelector("#timetables tr:last-child select"), timetable.DayOfWeek);
                Driver.Current.FindElement(By.CssSelector("#timetables tr:last-child .departure input")).SendKeys(timetable.DepartureTime.ToString());
                Driver.Current.FindElement(By.CssSelector("#timetables tr:last-child .arrival input")).SendKeys(timetable.ArrivalTime.ToString());
            }
            Driver.Current.FindElement(By.Id("save")).Click();

            Driver.Current.WaitUntilElementIsVisible(By.Id("loading"));
        }
    }
}