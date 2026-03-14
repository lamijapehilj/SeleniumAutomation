using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Data;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumLearning
{
    public class Lam4
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

        public void SortTable()
        {

            ArrayList a = new ArrayList();

            IWebElement dropDown = driver.FindElement(By.Id("page-menu"));
            SelectElement s = new SelectElement(dropDown);

            s.SelectByValue("20");

            //step 1 - Get all veggie names into array list A

            IList<IWebElement> listA = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggies in listA)
            {
                a.Add(veggies.Text);

            }

            //step 2 - Sort this array list

            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine("After sorting " + element);
            }


            //step 3 - go and click column

            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();

            //stap 4 Get all veggie names into array list B

            

            ArrayList b = new ArrayList();

            IList<IWebElement> veggiesB = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggies in veggiesB)
            {
                b.Add(veggies.Text);
            }

            //araylist A to B = equal

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
