using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelpers
{
    public  class WindowHelper
    {
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title.ToString();
        }
    }
}
