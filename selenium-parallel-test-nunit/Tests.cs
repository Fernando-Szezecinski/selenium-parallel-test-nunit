using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace selenium_parallel_test_nunit
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : Hooks
    {

        public FirefoxTesting() : base(BrowserType.Firefox)
        {

        }

        [Test]
        public void FirefoxTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("selenium");
            Thread.Sleep(600);
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.That(Driver.PageSource.Contains("selenium"), Is.EqualTo(true), "The text selenium doesn't exist");
        }
    }

    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting() : base(BrowserType.Chrome)
        {

        }

        [Test]
        public void ChromeTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("selenium grid");
            Thread.Sleep(600);
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.That(Driver.PageSource.Contains("selenium grid"), Is.EqualTo(true), "The text selenium doesn't exist");
        }
    }
}