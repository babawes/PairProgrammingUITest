using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PairProgrammingUITest
{
    [TestClass]
    public class UITest
    {
        private IWebDriver _driver;
        private string url = "file:///C:/Users/aksel/OneDrive%20-%20Zealand%20Sj%C3%A6llands%20Erhvervsakademi/Interdisciplinary%20Assignments/Tredje%20semester/PairProgramming/Webpage/index.html";

        [TestMethod]
        public void ShowAllTest()
        {
            using (_driver = new ChromeDriver()) {

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("showallbutton")).Click();

                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("li")).Displayed);

                IWebElement unlist = _driver.FindElement(By.Id("allrecords"));
                ReadOnlyCollection<IWebElement> children = unlist.FindElements(By.Name("r"));

                Assert.IsTrue(children.Count > 0);
            }
        }
        [TestMethod]
        public void ShowByTitleTest()
        {
            using (_driver = new ChromeDriver())
            {

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("titleinput")).SendKeys("a");
                _driver.FindElement(By.Id("showbytitlebutton")).Click();

                wait.Until(webDriver => webDriver.FindElement(By.Name("tr")).Displayed);

                
                

                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ShowByArtistTest()
        {
            
        }

        [TestMethod]
        public void ShowByGenreTest()
        {
            using (_driver = new ChromeDriver())
            {

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("showallbutton")).Click();

                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("li")).Displayed);

                IWebElement unlist = _driver.FindElement(By.Id("allrecords"));
                ReadOnlyCollection<IWebElement> children = unlist.FindElements(By.Name("r"));

                Assert.IsTrue(children.Count > 0);
            }
        }
    }
}
