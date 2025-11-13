using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OrangeHRMFramework.Utils
{
    public static class WaitHelper
    {
        // 🔹 Wait until element is visible
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        // 🔹 Wait until element is clickable
        public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
