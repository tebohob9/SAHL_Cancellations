using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SAHL_Cancellations.Utilities
{
    public static class ReusableMethods
    {
        // Extension method for IWebElement to click on an element
        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        // Extension method for IWebElement to enter text into an input field
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        // Extension method for IWebElement to select a dropdown option by visible text
        public static void SelectDropDownText(this IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }

        // Extension method for IWebDriver to select a dropdown option by visible text
        public static void SelectDropDownText(this IWebDriver driver, By locator, string text)
        {
            var element = driver.FindElement(locator);
            new SelectElement(element).SelectByText(text);
        }

        // Extension method for IWebDriver to select a dropdown option by value
        public static void SelectDropDownValue(this IWebDriver driver, By locator, string value)
        {
            var element = driver.FindElement(locator);
            new SelectElement(element).SelectByValue(value);
        }

        // Extension method for IWebDriver to select a dropdown option by index
        public static void SelectDropDownIndex(this IWebDriver driver, By locator, int index)
        {
            var element = driver.FindElement(locator);
            new SelectElement(element).SelectByIndex(index);
        }
    }
}




