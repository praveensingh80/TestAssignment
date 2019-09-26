using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Framework.Config;
using Framework.Helpers;
using System;

namespace Framework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public static void InitializeSettings(string testSettingName = "dev")
        {
            //Set all the framework settings
            ConfigReader.SetFrameworkSettings(testSettingName);

            //Set log
            LogHelpers.CreateLogFile();

            //Open browser
            OpenBrowser(Settings.BrowserType);

            LogHelpers.Write("Initialized settings!!!");
        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--incognito", "--start-maximized");
                    options.AddArguments("--ignore-certificate-errors");
                    DriverContext.Driver = new ChromeDriver(options);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the application");
        }
    }   
}
