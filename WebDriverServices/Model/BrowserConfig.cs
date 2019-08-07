using System.Collections.Generic;

namespace WebDriverServices.Model
{
    public class BrowserConfig
    {
        public Browser Browser { get; set; }
        public string WebDriverPath { get; set; }
        public IList<string> BrowserOptions { get; set; }
    }
}
