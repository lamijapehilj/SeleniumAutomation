using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpSelFramework.pageObjects
{
    public class CheckoutPage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }


        public void checkout()
        {
            checkoutButton.Click();
        }
    }
}
