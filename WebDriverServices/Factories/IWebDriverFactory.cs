using OpenQA.Selenium;
using WebDriverServices.Model;

namespace WebDriverServices.Factories
{
    internal interface IWebDriverFactory
    {
        IWebDriver BuildAndGetWebDriver(BrowserConfig browserConfig);
    }
}
