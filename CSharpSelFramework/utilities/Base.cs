using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using NUnit.Framework.Legacy;


namespace CSharpSelFramework

{

    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--remote-allow-origins=*");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(5));

            driver.Manage().Window.Maximize();

            driver.Url = ("https://rahulshettyacademy.com/loginpagePractise/");
        }


        [TearDown]

        public void QuitBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
