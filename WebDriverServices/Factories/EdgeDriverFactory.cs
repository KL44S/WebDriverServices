using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverServices.Model;

namespace WebDriverServices.Factories
{
    internal class EdgeDriverFactory : WebDriverFactory
    {
        public EdgeDriverFactory() : base(Browser.Edge)
        {
        }

        protected override IWebDriver DoBuildAndGetWebDriver(BrowserConfig browserConfig)
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            IWebDriver webDriver = new EdgeDriver(browserConfig.WebDriverPath);

            return webDriver;
        }
    }
}
