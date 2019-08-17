using System;
using OpenQA.Selenium;
using WebDriverServices.Exceptions;
using WebDriverServices.Factories;
using WebDriverServices.Model;

namespace WebDriverServices
{
    public class WebDriverProvider
    {
        private readonly static int SecondsToWaitForElement = 10;
        private readonly static int SecondsToWaitForPageLoad = 15;
        private readonly static int SecondsToWaitForJsLoad= 15;
        private readonly static int MaxAttempsNumber = 3;

        private static IWebDriverFactory WebDriverFactory;

        public static IWebDriver BuildAndGetWebDriver(BrowserConfig browserConfig)
        {
            ValidateBrowserConfig(browserConfig);

            IWebDriver webDriver = null;
            int attempsNumber = 0;
            bool browserCreated = false;

            IWebDriverFactory webDriverFactory = GetWebDriverFactory();

            while (!browserCreated && attempsNumber < MaxAttempsNumber)
            {
                try
                {
                    webDriver = webDriverFactory.BuildAndGetWebDriver(browserConfig);                 

                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SecondsToWaitForElement);
                    webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(SecondsToWaitForJsLoad);
                    webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(SecondsToWaitForPageLoad);

                    browserCreated = true;
                }
                catch (Exception ex)
                {
                    browserCreated = false;
                    attempsNumber++;

                    if (ex is UnknownBrowserException || attempsNumber < MaxAttempsNumber)
                    {
                        throw ex;
                    }
                }
            }

            return webDriver;
        }

        private static void ValidateBrowserConfig(BrowserConfig browserConfig)
        {
            if (browserConfig == null)
            {
                throw new ArgumentNullException("No BrowserConfig provided");
            }

            if (string.IsNullOrEmpty(browserConfig.WebDriverPath))
            {
                throw new ArgumentException("No WebDriverPath provided");
            }
        }

        private static IWebDriverFactory GetWebDriverFactory()
        {
            if (WebDriverFactory == null)
            {
                WebDriverFactory webDriverFactory = new ChromeDriverFactory();
                webDriverFactory.SetNextFactory(new FirefoxDriverFactory());
                webDriverFactory.SetNextFactory(new EdgeDriverFactory());
                webDriverFactory.SetNextFactory(new OperaDriverFactory());

                WebDriverFactory = webDriverFactory;
            }

            return WebDriverFactory;
        }
    }
}
