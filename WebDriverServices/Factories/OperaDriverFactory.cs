using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using WebDriverServices.Model;

namespace WebDriverServices.Factories
{
    internal class OperaDriverFactory : WebDriverFactory
    {
        public OperaDriverFactory() : base(Browser.Opera)
        {
        }

        protected override IWebDriver DoBuildAndGetWebDriver(BrowserConfig browserConfig)
        {
            OperaDriverService operaDriverService = OperaDriverService.CreateDefaultService(browserConfig.WebDriverPath);
            OperaOptions operaOptions = new OperaOptions();
            operaOptions.BinaryLocation = browserConfig.WebDriverPath + "opera.exe";

            if (browserConfig.BrowserOptions != null)
            {
                operaOptions.AddArguments(browserConfig.BrowserOptions);
            }

            IWebDriver webDriver = new OperaDriver(operaDriverService, operaOptions);

            return webDriver;
        }
    }
}
