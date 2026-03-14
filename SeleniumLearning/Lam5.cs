using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Data;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning;

public class Lam5
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

        driver.Url = ("https://rahulshettyacademy.com/seleniumPractise/#/offers");
    }

    [Test]
    public void Test1()
    {
        //step 1 - Get all veggie names into array list A

        IWebElement dropdopwn = driver.FindElement(By.Id("page-menu"));

        SelectElement s = new SelectElement(dropdopwn);

        s.SelectByValue("20");

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Almond']")));

        //step 2 - Sort this array list

        ArrayList a = new ArrayList();

        IList<IWebElement> veggie = driver.FindElements(By.XPath("//tr/td[1]"));

        foreach (IWebElement element in veggie)
        {
            a.Add(element.Text);
        }

       



        //step 3 - go and click column
        a.Sort();

        foreach(String veggieText in a)
        {
            TestContext.Progress.WriteLine(a);
        }

        //stap 4 Get all veggie names into array list B

        driver.FindElement(By.CssSelector("th[aria-label *= 'Veg/fruit']")).Click();
        ArrayList b = new ArrayList();

        IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

        foreach(IWebElement element in sortedVeggies)
        {
            b.Add(element.Text); 
        }

        foreach(String veggiesText in b)
        {
            TestContext.Progress.WriteLine(b);
        }




        //araylist A to B = equal

        Assert.That(a, Is.EqualTo(b));

    }


    [TearDown]

    public void StopBrowser()
    {
        if(driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }

    }

}
