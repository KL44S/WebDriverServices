using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverServices
{
    public class WebDriverUtils
    {
        private readonly static int SecondsToWait = 10;

        public static IWebElement FindElement(IWebDriver webDriver, By by)
        {
            WebDriverWait Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(SecondsToWait));
            IWebElement DynamicElement = Wait.Until<IWebElement>(d => d.FindElement(by));

            return DynamicElement;
        }

        public static void GoToUrl(IWebDriver webDriver, string url)
        {
            int triesNumber = 0;
            bool success = false;
            int maxTriesNumber = 3;

            while (!success && (triesNumber < maxTriesNumber))
            {
                try
                {
                    webDriver.Navigate().GoToUrl(url);
                    
                    success = true;
                }
                catch (Exception) { }

                triesNumber++;
            }

            if (!success)
            {
                throw new TimeoutException();
            }
        }

        public static IEnumerable<IWebElement> FindElements(IWebDriver webDriver, By by)
        {
            WebDriverWait Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(SecondsToWait));
            IEnumerable<IWebElement> DynamicElements = Wait.Until<IEnumerable<IWebElement>>(d => d.FindElements(by));

            return DynamicElements;
        }

        public static void NavigateTo(IWebDriver webDriver, string url)
        {
            try
            {
                webDriver.Navigate().GoToUrl(url);

                IAlert alert = webDriver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException) { }
        }

        public static void Dispose(IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                webDriver.Dispose();
            }
        }
    }
}
