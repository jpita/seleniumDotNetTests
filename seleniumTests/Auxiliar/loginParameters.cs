using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTests
{
    public class loginParameters
    {
        public loginParameters(IWebDriver driver, String url, String userName, String password)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                // Find the text input element by its name
                driver.FindElement(By.Name("j_username")).SendKeys(userName);

                // Find the text input element by its name
                driver.FindElement(By.Name("j_password")).SendKeys(password);

                // Find the text input element by its name driver.findElement(By.xpath("//input[@alt='login']"));
                driver.FindElement(By.XPath("//input[@alt='login']")).Click();

                // Wait for the page to load, timeout after 10 seconds
                Logger.Out(DateTime.Now.ToString());
                Logger.Out("\nWait for 10 seconds\n");
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until((d) => { return d.FindElement(By.XPath("//img[@alt='Menu Principal']")); });

                Logger.Out(DateTime.Now.ToString());
                Logger.Out("\nDID I WAIT??\n");

                if (driver.FindElement(By.XPath("//img[@alt='Menu Principal']")).Enabled)
                {
                    Logger.Out("\nHOORRAAAYYY MOFO!!!\n");//img src="/vtcimg/header/pt_BR/bt_menu.gif" //alt="Menu Principal"
                }
                else
                {
                    Logger.Out("\nFUCKIN HELL!!!\n");
                }
                //Logger.Out( wait.Until );
                Logger.Out(driver.Url.ToString());

                //writes the page title to the console
                Logger.Out("Page title is: " + driver.Title);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
