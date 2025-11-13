using OpenQA.Selenium;
using OrangeHRMFramework.Drivers;
using OrangeHRMFramework.Utils;

namespace OrangeHRMFramework.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        // 🔹 Constructor links driver from DriverManager
        public LoginPage()
        {
            driver = DriverManager.driver;
        }

        // 🔹 Locators
        private By usernameField = By.Name("username");
        private By passwordField = By.Name("password");
        private By loginButton = By.XPath("//button[@type='submit']");

        // 🔹 Actions
        public void EnterUsername(string username)
        {
            WaitHelper.WaitForElementVisible(driver, usernameField, ConfigReader.GetInt("DefaultWaitTimeInSeconds"))
                .SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            WaitHelper.WaitForElementVisible(driver, passwordField, ConfigReader.GetInt("DefaultWaitTimeInSeconds"))
                .SendKeys(password);
        }

        public void ClickLogin()
        {
            WaitHelper.WaitForElementClickable(driver, loginButton, ConfigReader.GetInt("DefaultWaitTimeInSeconds"))
                .Click();
        }
    }
}
