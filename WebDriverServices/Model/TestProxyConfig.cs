using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebDriverServices.Model
{
    public class TestProxyConfig
    {
        public string TestPageUrl { get; set; }
        public IList<By> Criteria { get; set; }
    }
}
