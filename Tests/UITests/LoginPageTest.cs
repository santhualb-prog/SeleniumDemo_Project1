using NUnit.Framework;
using OrangeHRMFramework.Drivers;
using OrangeHRMFramework.Pages;
using OrangeHRMFramework.Utils;
using System;

namespace OrangeHRMFramework.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private LoginPage loginPage;
        private string username;
        private string password;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            ExtentReportManager.InitReport();

            // 🔹 Read credentials from JSON
            username = TestDataReader.GetTestData("LoginData.json", "username");
            password = TestDataReader.GetTestData("LoginData.json", "password");
        }

        [SetUp]
        public void Setup()
        {
            DriverManager.InitDriver();
            DriverManager.driver.Navigate().GoToUrl(ConfigReader.Get("BaseUrl"));

            loginPage = new LoginPage();
            ExtentReportManager.CreateTest("Verify Login With Valid Credentials");
        }

        [Test]
        public void VerifyLoginWithValidCredentials()
        {
            try
            {
                loginPage.EnterUsername(username);
                loginPage.EnterPassword(password);
                loginPage.ClickLogin();

                Assert.That(DriverManager.driver.Url.Contains("dashboard"), "Login failed or Dashboard not loaded");

                ExtentReportManager.LogPass("Login test passed successfully!");
                ScreenshotHelper.Capture(DriverManager.driver, "LoginSuccess");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message ?? "Unknown error occurred";
                ExtentReportManager.LogFail($"Login test failed: {errorMessage}");
                ScreenshotHelper.Capture(DriverManager.driver, "LoginFailed");
                Assert.Fail(errorMessage);
            }
        }

        [TearDown]
        public void Cleanup()
        {
            DriverManager.QuitDriver();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            ExtentReportManager.FlushReport();
        }
    }
}
