using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebDriverServices
{
    public class WebDriverConnectionTester
    {
        private readonly static string TestPage = @"http://www.google.com.ar/";
        private readonly static IList<By> Criteria = new List<By>()
        {
             By.XPath("//body[@id='t']")
        };

        public static bool TestConnection(IWebDriver webDriver)
        {
            bool thereIsConnection = true;

            try
            {
                SeleniumUtils.GoToUrl(webDriver, TestPage);

                try
                {
                    FindElement(webDriver);
                }
                catch (NoSuchElementException)
                {
                    thereIsConnection = false;
                }
            }
            catch (Exception)
            {
                thereIsConnection = false;
            }
            finally
            {
                if (webDriver != null)
                {
                    webDriver.Quit();
                }
            }

            return thereIsConnection;
        }

        private static void FindElement(IWebDriver webDriver)
        {
            IWebElement goodConnectionElement = null;

            foreach (By by in Criteria)
            {
                ISearchContext searchContext;

                if (goodConnectionElement != null)
                {
                    searchContext = goodConnectionElement;
                }
                else
                {
                    searchContext = webDriver;
                }

                goodConnectionElement = searchContext.FindElement(by);
            }
        }
    }
}
