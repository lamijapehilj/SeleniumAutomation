using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {
        IWebDriver driver;
  

       [SetUp]

        public void StartBrowser()
        {
            //Methods - geturl,click
            //chromedriver.exe on chrome browser
            //edgedriver.exe
            //geckodriver (Firefox .exe)
            //99.exe fro existing chrome browser (99)
            //WebDriverManager-(
            // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new ChromeDriver();
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

            //driver = new FirefoxDriver();
            driver = new EdgeDriver();

            
            driver.Manage().Window.Maximize();
            
        }

        [Test]

        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/"; //setting the property
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);  //getting the property
            
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            //driver.Quit(); //2 windows, quit all windows
        }
    }

}
