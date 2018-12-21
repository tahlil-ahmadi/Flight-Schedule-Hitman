using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.AcceptanceTests.UI.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace FlightSchedule.AcceptanceTests.UI.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        private readonly ScenarioContext _context;
        public WebDriverHook(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario("UI")]
        public void SetupDriver()
        {
            Driver.Current = new ChromeDriver();
        }

        [AfterScenario("UI")]
        public void TeardownDriver()
        {
            if (this._context.TestError != null)
            {
                var screenshot = ((ITakesScreenshot) Driver.Current).GetScreenshot();
                screenshot.SaveAsFile(@"2.png", ScreenshotImageFormat.Png);
            }

            Driver.Current.Close();
        }
    }
}
