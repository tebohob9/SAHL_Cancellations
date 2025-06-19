using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SAHL_Cancellations.Utilities
{
    public class WebDriverManager
    {
        private static WebDriverManager _instance;
        private IWebDriver _driver;

        // Private constructor to prevent direct instantiation
        private WebDriverManager() { }

        // Public property to access the Singleton instance
        public static WebDriverManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WebDriverManager();
                }
                return _instance;
            }
        }

        // Method to return the WebDriver instance
        public IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                // Initialize WebDriver (here it's Chrome; you can change it to Firefox, Edge, etc.)
                _driver = new ChromeDriver();
            }
            return _driver;
        }

        // Optionally, quit the driver (if needed at the end of the session)
        public void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}


