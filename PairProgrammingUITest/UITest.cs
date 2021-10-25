using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PairProgrammingUITest
{
    [TestClass]
    public class UITest
    {
        private IWebDriver _driver;
        private string url = "file:///C:/Users/babaw/OneDrive/Skrivebord/Sem.%203/PairProgramming/PairProgrammingWebpage/index.html";

        [TestMethod]
        public void ShowAllTest()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.FindElement(By.Id("showallbutton")).Click();
            string listText = _driver.FindElement(By.Id("allrecords")).Text;
            Assert.IsFalse(string.IsNullOrEmpty(listText));
        }
    }
}
