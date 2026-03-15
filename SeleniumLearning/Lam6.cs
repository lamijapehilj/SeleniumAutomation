using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.ComponentModel.Design;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning;

public class Lam6
{

    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Url = ("https://rahulshettyacademy.com/AutomationPractice/");

        driver.Manage().Window.Maximize();




    }

    [Test]
    public void Allerts()
    {
        String name = "Rahul";
        driver.FindElement(By.Id("name")).SendKeys(name);
        driver.FindElement(By.CssSelector("input[value = 'Alert']")).Click();

        
        driver.SwitchTo().Alert().Accept();

        StringAssert.Contains(name, "Rahul");


    }

    [Test]
    public void dragAndDrop()
    {

        driver.Url = ("https://demoqa.com/droppable");
        Actions a = new Actions(driver);
        a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();

        string classValue = driver.FindElement(By.Id("droppable")).GetAttribute("class");

        StringAssert.Contains("ui-state-highlight", classValue);

    }

    [Test]

    public void iNdia()
    {
        driver.FindElement(By.CssSelector("input[id = 'autocomplete']")).SendKeys("ind");

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".ui-menu-item div")));
        IList<IWebElement> lista = driver.FindElements(By.CssSelector(".ui-menu-item div"));

        foreach (IWebElement element in lista)
        {
            Console.WriteLine(element.Text);

            if(element.Text == "India")
            {
                element.Click();
                break;
            }
        }

        TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
    }


    [TearDown]

    public void closeBrowser()
    {
        if(driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
