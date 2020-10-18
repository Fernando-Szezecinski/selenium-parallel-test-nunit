using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace selenium_parallel_test_nunit
{

    public enum BrowserType
    {
        Chrome,
        Firefox
    }


    [TestFixture]
    public class Hooks : Base
    {
        private BrowserType _browserType;

        public Hooks(BrowserType browser)
        {
            _browserType = browser;
        }

        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(_browserType);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }


        private void ChooseDriverInstance(BrowserType browser)
        {
            if (browser.Equals(BrowserType.Chrome))
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                Driver = new ChromeDriver();
            }
            else
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                Driver = new FirefoxDriver();
            }
        }

    }
}
