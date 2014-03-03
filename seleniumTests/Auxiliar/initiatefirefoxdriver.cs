using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTests
{
    public class InitiateFirefoxDriver
    {
        IWebDriver driver = null;
        public InitiateFirefoxDriver()
        {
            Logger.Out("\n Initiate Firefox Driver");
            driver = new FirefoxDriver();
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
