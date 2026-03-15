using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    public class Locators
    {
        //Xpath, Css, id, classname, name, tagname, linktext

        IWebDriver driver;

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

            //Implicit wait 5 sec can be declared globally


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = ("https://rahulshettyacademy.com/loginpagePractise/");
        }

        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            //css selector & xpath
            // tagname[attribute = 'value']  CSS
            // #id #terms - css short 
            //.text-info span:nth-child(1) input  from parent to child CSS
            //c-path same as above: //label[@class = 'text-info']/span/input

            //driver.FindElement(By.CssSelector("input[value = 'Sign In']")).Click();

            // //tagName[@attribute = 'value']  Xpath
            driver.FindElement(By.XPath("//div[@class = 'form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.XPath("//input[@value = 'Sign In']")).Click();

            //Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.CssSelector("#signInBtn")), "Sign In"));

            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));

            //validate url of the link text
            String hrefAtttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            Assert.That(hrefAtttr, Is.EqualTo(expectedUrl));
            

        }

        [TearDown]

        public void StopBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
