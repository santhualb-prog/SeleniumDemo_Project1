using OpenQA.Selenium;
using System;
using System.IO;

namespace OrangeHRMFramework.Utils
{
    public static class ScreenshotHelper
    {
        public static string Capture(IWebDriver driver, string screenshotName)
        {
            try
            {
                // 🔹 Wait a few seconds to let page load
        System.Threading.Thread.Sleep(1000); // 1 second pause (simple but effective)
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string folderPath = Path.Combine(projectRoot, "Screenshots");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string filePath = Path.Combine(folderPath, $"{screenshotName}_{timestamp}.png");

                // Take screenshot
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                // Modern Selenium: Save file using extension only, no enum required
                ss.SaveAsFile(filePath); // Save automatically as PNG because path ends with .png

                return filePath;
            }
            catch
            {
                return ""; // return empty string if fails
            }
        }
    }
}
