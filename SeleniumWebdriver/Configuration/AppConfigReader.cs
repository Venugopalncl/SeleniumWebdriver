using SeleniumWebdriver.Interfaces;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            //We need additional step then typecost in enum type
            //return Enum.Parse(typeof(BrowserType), browser); returning object , we have to chnage to BrowserType
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);

        }
        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);

        }
        public int GetPageLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout is null)
                return 30;
                return Convert.ToInt32(timeout);
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeOut);
            if (timeout is null)
                return 30;
            return Convert.ToInt32(timeout);
        }
    }
}
