using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverServices.Model;

namespace WebDriverServices.Factories
{
    internal class ChromeDriverFactory : WebDriverFactory
    {
        public ChromeDriverFactory() : base(Browser.Chrome)
        {
        }

        protected override IWebDriver DoBuildAndGetWebDriver(BrowserConfig browserConfig)
        {
            IWebDriver webDriver = null;

            if (browserConfig.BrowserOptions != null)
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments(browserConfig.BrowserOptions);

                webDriver = new ChromeDriver(browserConfig.WebDriverPath, chromeOptions);
            }
            else
            {
                webDriver = new ChromeDriver(browserConfig.WebDriverPath);
            }

            return webDriver;
        }
    }
}
