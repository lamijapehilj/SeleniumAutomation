using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumLearning;

public class AlertsactionsAutoSuggestive
{

    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--remote-allow-origins=*");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");

        driver = new ChromeDriver(options);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Url = ("https://rahulshettyacademy.com/AutomationPractice/");

    }

    [Test]

    public void frames()
    {
        //Scroll until element if it is in headless name:
        //a) desclare one web element frame scroll
        
        IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));

        //b) pass it to js executor for scrooling until that element

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

        //id, name, index
        driver.SwitchTo().Frame("courses-iframe");
        driver.FindElement(By.LinkText("All Access Plan")).Click();
        TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        String firstText = driver.FindElement(By.CssSelector("h1")).Text;

        //Go back to brpwser page, from iframe
        driver.SwitchTo().DefaultContent();
        TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        String secondText = driver.FindElement(By.CssSelector("h1")).Text;

        Assert.That(firstText, Is.Not.EqualTo(secondText), "Texts should be different because one is inside iframe.");

    }


    [Test]
    public void Alert()
    {

        String name = "Rahul";

        driver.FindElement(By.Id("name")).SendKeys(name);
        driver.FindElement(By.CssSelector("input[onclick *='displayConfirm']")).Click();

        String alertText = driver.SwitchTo().Alert().Text;
        driver.SwitchTo().Alert().Accept();
        //driver.SwitchTo().Alert().Dismiss();
        //driver.SwitchTo().Alert().SendKeys("hello");

        StringAssert.Contains(name, alertText);
    }


    [Test]

    public void AutoSuggestiveDropDowns()
    {
        driver.FindElement(By.Id("autocomplete")).SendKeys("Ind");
        Thread.Sleep(3000);

        IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

        foreach (IWebElement option in options)
        {
            if (option.Text.Equals("India"))
            {
                option.Click();

            }

        }
        TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));

    }




        [Test]

        public void test_Actions()
        {
        //    driver.Url = ("https://rahulshettyacademy.com");

           Actions a = new Actions(driver);
        //    a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();

        //driver.FindElement(By.XPath("ul[class='dropdown-menu]/li[1]/a")).Click();

        //Ako hocemo Actions menthod:
        //a.MoveToElement(driver.FindElement(By.XPath("ul[class='dropdown-menu]/li[1]/a"))).Click().Perform();

        driver.Url = ("https://demoqa.com/droppable");
        a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();


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
