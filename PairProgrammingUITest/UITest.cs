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

                Assert.IsTrue(wait.Until(webDriver => webDriver.FindElement(By.Name("tr")).Displayed));
            }
        }

        [TestMethod]
        public void ShowByArtistTest() {
            using (_driver = new ChromeDriver()) {

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("artistinput")).SendKeys("a");
                _driver.FindElement(By.Id("showbyartistbutton")).Click();

                Assert.IsTrue(wait.Until(webDriver => webDriver.FindElement(By.Name("ar")).Displayed));
            }
        }

        [TestMethod]
        public void ShowByGenreTest() {
            using (_driver = new ChromeDriver()) {

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("genreinput")).SendKeys("p");
                _driver.FindElement(By.Id("showbygenrebutton")).Click();

                Assert.IsTrue(wait.Until(webDriver => webDriver.FindElement(By.Name("gr")).Displayed));
            }
        }
        [TestMethod]
        public void AddMusicRecordTest() {
            using (_driver = new ChromeDriver()) {

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("showallbutton")).Click();

                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("li")).Displayed);

                int oldNrOfRecords = _driver.FindElements(By.CssSelector("li")).Count;

                _driver.FindElement(By.Id("titleaddinput")).SendKeys("title");
                _driver.FindElement(By.Id("artistaddinput")).SendKeys("artist");
                _driver.FindElement(By.Id("durationaddinput")).SendKeys("90");
                _driver.FindElement(By.Id("yearaddinput")).SendKeys("2000");
                _driver.FindElement(By.Id("genreaddinput")).SendKeys("genre");

                _driver.FindElement(By.Id("addbutton")).Click();

                DateTime start = System.DateTime.Now;
                wait.Until(webDriver => {
                    if(System.DateTime.Now > start.AddSeconds(1)) {
                        return true;
                    }
                    return false;
                });

                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.Id("showallbutton")).Click();

                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("li")).Displayed);

                int newNrOfRecords = _driver.FindElements(By.CssSelector("li")).Count;

                Assert.AreEqual(oldNrOfRecords+1, newNrOfRecords);
            }
        }
    }
}