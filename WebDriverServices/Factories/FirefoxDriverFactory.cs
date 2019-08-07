using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverServices.Model;

namespace WebDriverServices.Factories
{
    internal class FirefoxDriverFactory : WebDriverFactory
    {
        public FirefoxDriverFactory() : base(Browser.Firefox)
        {
        }

        protected override IWebDriver DoBuildAndGetWebDriver(BrowserConfig browserConfig)
        {
            FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService(browserConfig.WebDriverPath);

            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.BrowserExecutableLocation = browserConfig.WebDriverPath + "firefox.exe";
            if (browserConfig.BrowserOptions != null)
            {
                firefoxOptions.AddArguments(browserConfig.BrowserOptions);
            }

            TimeSpan TimeSpan = new TimeSpan(1, 0, 0);
            IWebDriver webDriver = new FirefoxDriver(firefoxDriverService, firefoxOptions, TimeSpan);

            return webDriver;
        }
    }
}
