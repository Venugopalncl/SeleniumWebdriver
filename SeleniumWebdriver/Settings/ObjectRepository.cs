﻿using OpenQA.Selenium;
using SeleniumWebdriver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Settings
{
    public class ObjectRepository
    {
        public static IConfig config { get; set; }
        public static IWebDriver Driver { get; set; }

    }
}
