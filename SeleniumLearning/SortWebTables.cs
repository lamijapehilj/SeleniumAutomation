using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumLearning
{
    public class SortWebTables
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

            driver.Url = ("https://rahulshettyacademy.com/seleniumPractise/#/offers");

        }

        [Test]

        public void SortTable()
        {
            IWebElement dropD = driver.FindElement(By.CssSelector("#page-menu"));

            SelectElement dd = new SelectElement(dropD);
            dd.SelectByValue("20");

            // step 1 - Get all veggie names into array list A

            ArrayList a = new ArrayList();

            IList <IWebElement> veggies =  driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }

            //step 2 - Sort this array list

            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            TestContext.Progress.WriteLine("After sorting");
            a.Sort();

            foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            // step 3 - Click the column

            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();
                //th[contains(@aria-label, 'fruit name')] - Xpath for the sam as above

            //step 4 - Get all veggie names into array list B

            ArrayList b = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }

            //arrayList A to B = equal

            Assert.That(a, Is.EqualTo(b));
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
