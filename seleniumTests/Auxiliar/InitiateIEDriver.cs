using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTests
{
    public class InitiateIEDriver
    {
        IWebDriver driver = null;
        public InitiateIEDriver()
        {
            //string IE_DRIVER_PATH = @"C:\selenium";
            string IE_DRIVER_PATH = @"C:\Users\jpita\Documents\Visual Studio 2013\Projects\ConsoleApplication2\packages";
            //System.Environment.SetEnvironmentVariable("webdriver.ie.driver", "C:\\selenium\\iedriver\\IEDriverServer.exe");
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
            };

            driver = new InternetExplorerDriver(IE_DRIVER_PATH, options);
        }
        public IWebDriver Driver
        {
            // Return the value stored in a field.
            get { return driver; }
            // Store the value in the field.
            set { driver = value; }
        }
    }
}
