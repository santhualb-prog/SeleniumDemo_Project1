using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRMFramework.Utils;

namespace OrangeHRMFramework.Drivers
{
    public static class DriverManager
    {
        // 🔹 Static driver instance used across pages/tests
        public static IWebDriver driver;

        // 🔹 Initialize WebDriver based on config (browser)
        public static void InitDriver()
        {
            string browser = ConfigReader.GetConfigValue("Browser"); // e.g., Chrome

            if (browser.ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            // 🔹 Add other browsers if needed: Firefox, Edge, etc.

            driver.Manage().Window.Maximize(); // Maximize browser window
        }

        // 🔹 Close and quit browser
        public static void QuitDriver()
        {
            driver.Quit();
        }
    }
}
