using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace seleniumTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Enable log4net
			//LoggingExtensions.Logging.Log.InitializeWith<LoggingExtensions.log4net.Log4NetLog>();
            //gets the driver needed to drive Internet Explorer
            //IWebDriver driver = new InitiateIEDriver().Driver;

            //gets the driver needed to drive Firefox
            IWebDriver driver = new InitiateFirefoxDriver().Driver;

            try
            {
                //new loginParameters(driver,"http://psf.testing.vitacare.pt:8100/", "julia.wambier", "teste");
                new GoogleSearch(driver, "banana", "banana");
            }
            catch (Exception ex)
            {
                Logger.Out(ex.Message);
            }
            finally
            {
                Logger.SaveToFile();
                //Close the browser
                driver.Quit();
                //Close the console
                Console.ReadLine();
            }
            
        }
    }
}
