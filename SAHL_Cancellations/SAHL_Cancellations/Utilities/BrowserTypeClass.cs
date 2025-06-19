using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SAHL_Cancellations.Utilities
{
    public enum Browser
    {
        Chrome,
        Firefox,
        Edge
    }

    public static class BrowserType
    {
        // This method should return the instance of the IWebDriver
        public static IWebDriver GetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    var chromeOptions = new ChromeOptions();
                    // Add any Chrome-specific options here
                    return new ChromeDriver(chromeOptions);

                case Browser.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    // Add any Firefox-specific options here
                    return new FirefoxDriver(firefoxOptions);

                case Browser.Edge:
                    var edgeOptions = new EdgeOptions();
                    // Add any Edge-specific options here
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new NotImplementedException($"Browser {browser} is not supported.");
            }
        }
    }
}


