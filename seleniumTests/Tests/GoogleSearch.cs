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
                Logger.Out("wait" + DateTime.Now);
                long end = System.DateTime.Now.Millisecond + 5000;
                while (System.DateTime.Now.Millisecond < end)
                {
                    IWebElement resultsDiv = driver.FindElement(By.ClassName("gssb_e"));

                    // If results have been returned, the results are displayed in a drop down.
                    if (resultsDiv.Displayed)
                    {
                        break;
                    }
                }
                Logger.Out("after wait" + DateTime.Now);
                driver.FindElement(By.Name("q")).SendKeys(Keys.Enter); 
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                Logger.Out("Driver title before wait =" + driver.Title);
                AuxFuncs.WaitForPageLoad(10000, driver);
                Logger.Out("Driver title after wait ="+driver.Title);
                Assert.AreEqual("banana - Pesquisa do Google", driver.Title);
                Console.WriteLine(); 
				Logger.Out("before wait"+driver.Title);
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
				wait.Until((d) => { return d.Title.StartsWith("selenium"); });
				//Check that the Title is what we are expecting
				Assert.AreEqual(p1+" - Pesquisa do Google", driver.Title);
				Logger.Out("after wait & assert"+driver.Title); 
            }
			catch (Exception ex)
            {
				throw ex;
            }
        }
    }
}
