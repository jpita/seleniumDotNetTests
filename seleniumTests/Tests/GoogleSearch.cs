﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace seleniumTests
{
    public class GoogleSearch
    {        
        public GoogleSearch(IWebDriver driver, string p1, string p2)
        {
            try
            {
                driver.Navigate().GoToUrl("http://www.google.com");

                driver.FindElement(By.Name("q")).SendKeys(p1);
                driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
                Logger.Out(driver.Title);
                Assert.AreEqual(" - Pesquisa do Google", driver.Title);
            }
            catch (NUnit.Framework.AssertionException ex)
            {

                throw ex;
            }
        }
    }
}
