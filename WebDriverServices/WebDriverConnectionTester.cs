using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebDriverServices.Model;

namespace WebDriverServices
{
    public class WebDriverConnectionTester
    {
        public static bool TestConnection(IWebDriver webDriver, TestProxyConfig testProxyConfig = null)
        {
            bool thereIsConnection = true;

            try
            {
                TestProxyConfig validTestProxyConfig = GetValidTestProxyConfig(testProxyConfig);

                WebDriverUtils.GoToUrl(webDriver, validTestProxyConfig.TestPageUrl);

                try
                {
                    FindElement(webDriver, validTestProxyConfig.Criteria);
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

        private static TestProxyConfig GetValidTestProxyConfig(TestProxyConfig testProxyConfig)
        {
            if (testProxyConfig == null)
            {
                testProxyConfig = new TestProxyConfig()
                {
                    TestPageUrl = @"http://www.google.com.ar/",
                    Criteria = new List<By>()
                    {
                         By.XPath("//body[@id='t']")
                    }
                };
            }

            return testProxyConfig;
        }

        private static void FindElement(IWebDriver webDriver, IList<By> Criteria)
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
