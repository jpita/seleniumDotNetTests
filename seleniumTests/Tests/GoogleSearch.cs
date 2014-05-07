using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LoggingExtensions.Logging;
using OpenQA.Selenium.Support.UI;


namespace seleniumTests
{
    public class GoogleSearch
    {        
        public GoogleSearch(IWebDriver driver, string p1, string p2)
        {
            try
            {
                driver.Navigate().GoToUrl("http://www.google.pt");

                driver.FindElement(By.Name("q")).SendKeys(p1);
                Logger.Out("Driver title before send keys enter =" + driver.Title);
                //get the suggestions box from google
                Logger.Out(DateTime.Now.ToString());
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                 wait.Until((d) => { return d.FindElement(By.ClassName("gssb_e")).Displayed; });
                IWebElement resultsDiv = driver.FindElement(By.ClassName("gssb_e"));
                Logger.Out(DateTime.Now.ToString());
                //// If results have been returned, the results are displayed in a drop down.
                if (resultsDiv.Displayed)
                {
                    Logger.Out("Suggestions appeared");
                }
                else
                    throw new Exception("No suggestions");
                driver.FindElement(By.Name("q")).SendKeys(Keys.Enter); 
				Logger.Out("before wait"+driver.Title);
				wait.Until((d) => { return d.Title.StartsWith("banana"); });
				//Check that the Title is what we are expecting
				Assert.AreEqual(p1+" - Pesquisa do Google", driver.Title);
				Logger.Out("after wait & assert- "+driver.Title);
            }
			catch (Exception ex)
            {
				throw ex;
            }
        }
    }
}
