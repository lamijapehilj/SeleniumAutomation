using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Data;
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
