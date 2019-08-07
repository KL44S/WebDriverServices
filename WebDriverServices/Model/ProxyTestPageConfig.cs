using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebDriverServices.Model
{
    public class ProxyTestPageConfig
    {
        public string Page;
        public string Proxy;
        public IList<By> Criteria;
        public Browser Browser;

        public ProxyTestPageConfig(string page, 
                                    string proxy,
                                    IList<By> criteria,
                                    Browser browser)
        {
            this.Page = page;
            this.Proxy = proxy;
            this.Criteria = criteria;
            this.Browser = browser;
        }

        public ProxyTestPageConfig(string proxy, Browser browser)
        {
            this.Proxy = proxy;
            this.Browser = browser;
        }
    }
}
