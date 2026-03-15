using CSharpSelFramework;
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

public class WindowHandlers : Base
{
   

    [Test]
    public void WindowHandler()
    {

        String email = "mentor@rahulshettyacademy.com";

        //Store the id of the current parent window to use it later in order ot switch back to parent window
        String parentWindowId = driver.CurrentWindowHandle;

        driver.FindElement(By.CssSelector(".blinkingText")).Click();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(d => d.WindowHandles.Count == 2);
        Assert.That(2, Is.EqualTo (driver.WindowHandles.Count));

        String childWindowName = driver.WindowHandles[1];

        driver.SwitchTo().Window(childWindowName);

        TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
        String text = driver.FindElement(By.CssSelector(".red")).Text;

        //Please email us at mentor@rahulshettyacademy.com with below template to receive response
        String[] splittedText = text.Split("at");
        //splittedText[1]; //mentor@rahulshettyacademy.com with below template to receive response

        String[] trimmedString = splittedText[1].Trim().Split(" ");
        Assert.That(email, Is.EqualTo(trimmedString[0]));

        driver.SwitchTo().Window(parentWindowId);

        driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);

    }


    
}
