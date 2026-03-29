using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using NUnit.Framework.Legacy;
using CSharpSelFramework;
using CSharpSelFramework.pageObjects;


namespace SeleniumLearning
{


    public class E2ETest : Base
    {

        [Test]

        public void EndToEndFlow()
        {

            String[] expectedProducts = { "iphone X", "Blackberry" };

            //expecting 2 peoducts in cart
            String[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(getDriver());


           ProductsPage productPage =  loginPage.validLogin("rahulshettyacademy", "Learning@830$3mK2");
            productPage.waitForPageDisplay();



            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.addToCartButton()).Click();
                    //click cart

                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }

            CheckoutPage checkoutPage = productPage.checkout();

            //check the checkout card which products do you have and confirm that those are the same you added in the cart
            IList<IWebElement> checkoutCarts = checkoutPage.getCards();

            for(int i = 0; i < checkoutCarts.Count; i++)
            {
                actualProducts[i] = checkoutCarts[i].Text;
            }

            // Ispiši sve dodane proizvode
            TestContext.Progress.WriteLine("Products added to cart: " + string.Join(", ", actualProducts));

            Assert.That(expectedProducts, Is.EqualTo(actualProducts));



            //driver.FindElement(By.CssSelector(".btn-success")).Click();
            checkoutPage.checkout();

            driver.FindElement(By.Id("country")).SendKeys("ind");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.CssSelector("label[for *= 'checkbox2']")).Click();

            driver.FindElement(By.CssSelector("[value = 'Purchase']")).Click();

            String confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirmText);




        }
    }
}
