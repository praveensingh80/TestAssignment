using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;
using System;
using Framework.Helpers;

namespace TestProject.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement btnAcceptCookies => DriverContext.Driver.FindElement(By.CssSelector("button[data-test='accept-cookies-button']"));

        private IWebElement lnkHandla => DriverContext.Driver.FindElement(By.CssSelector("a[data-test='Handla']"));

        private IWebElement lnkBredbandsabonnemang => DriverContext.Driver.FindElement(By.CssSelector("a[data-test='Bredbandsabonnemang']"));

        public void ClickHandla()
        {
            CheckIfHandlaLinkExist();
            lnkHandla.Click();            
        }

        public BredbandPage ClickBredbandsabonnemang()
        {
            lnkBredbandsabonnemang.Click();
            return GetInstance<BredbandPage>();
        }

        private void CheckIfHandlaLinkExist()
        {
            lnkHandla.AssertElementPresent();
        }

        public void HandleGDPRCookiesPopUpIfExist()
        {
            try
            {
                btnAcceptCookies.AssertElementPresent();
                btnAcceptCookies.Click();
            }
            catch (Exception e)
            {
                if (e.Message == "Element not present exception")
                    LogHelpers.Write("Cookies already handled");
                else
                    throw e;
            }
        }
    }
}
