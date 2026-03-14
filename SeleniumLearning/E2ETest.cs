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


    public class E2ETest
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

            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(5));

            driver.Manage().Window.Maximize();

            driver.Url = ("https://rahulshettyacademy.com/loginpagePractise/");

        }

        [Test]

        public void EndToEndFlow()
        {

            String[] expectedProducts = { "iphone X", "Blackberry" };


            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");

            driver.FindElement(By.Name("password")).SendKeys("Learning@830$3mK2");

            driver.FindElement(By.XPath("//div[@class = 'form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.XPath("//input[@value = 'Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                    //click cart

                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }



            driver.FindElement(By.PartialLinkText("Checkout")).Click();

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
