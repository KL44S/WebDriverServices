using OpenQA.Selenium;
using WebDriverServices.Exceptions;
using WebDriverServices.Model;

namespace WebDriverServices.Factories
{
    internal abstract class WebDriverFactory : IWebDriverFactory
    {
        protected readonly Browser Browser;
        protected WebDriverFactory NextWebDriverFactory;

        public WebDriverFactory(Browser browser)
        {
            this.Browser = browser;
        }

        public IWebDriver BuildAndGetWebDriver(BrowserConfig browserConfig)
        {
            if (browserConfig.Browser.Equals(this.Browser))
            {
                return this.DoBuildAndGetWebDriver(browserConfig);
            }
            else if (this.NextWebDriverFactory != null)
            {
                return this.NextWebDriverFactory.BuildAndGetWebDriver(browserConfig);
            }
            else
            {
                throw new UnknownBrowserException();
            }
        }

        public void SetNextFactory(WebDriverFactory webDriverFactory)
        {
            if (this.NextWebDriverFactory == null)
            {
                this.NextWebDriverFactory = webDriverFactory;
            }
            else
            {
                this.NextWebDriverFactory.SetNextFactory(webDriverFactory);
            }
        }

        protected abstract IWebDriver DoBuildAndGetWebDriver(BrowserConfig browserConfig);
    }
}
