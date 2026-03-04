using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V143.DOMSnapshot;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class FunctionalTest
    {

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


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = ("https://rahulshettyacademy.com/loginpagePractise/");
        }

        [Test]
        public void dropdown()

        {
            IWebElement dropDown = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropDown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1);

           IList <IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach(IWebElement radioButton in rdos)
            if(radioButton.GetAttribute("value").Equals("user"))
                    {
                    radioButton.Click();
                }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;

            Assert.That(result, Is.False);

        }

        [TearDown]

        public void stopBrowser()
        {
            driver.Quit();
        }
    }
}
