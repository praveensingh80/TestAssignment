using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace TestProject.Pages
{
    public class BredbandPage : BasePage
    {
        private IWebElement txtAddress => DriverContext.Driver.FindElement(By.Id("Address"));

        private IWebElement ddApartmentNumber => DriverContext.Driver.FindElement(By.Id("vue-dropdown-40"), 5, true);

        private IReadOnlyCollection<IWebElement> headerBredbandPlans => DriverContext.Driver.FindElements(By.CssSelector("button[data-test='select-button']"), 5);


        public void SearchBredbandPlanForAddress(string gatuAdress, string lagenhetsnummer)
        {
            CheckIfAddressSearchExist();
            FillAddress(gatuAdress);            
            ddApartmentNumber.SelectDropDownList(lagenhetsnummer);
        }

        private void FillAddress(string address)
        {
            txtAddress.SendKeys(address);            
            DriverContext.Driver.FindElement(By.XPath("//li[contains(text(),'"+address.ToUpper()+"')]"), 5, true).Click();            
        }

        public IList<string> GetOfferedBredbandPlans()
        {
            IList<string> bredbandPlanTitle = new List<string>();
            foreach(IWebElement header in headerBredbandPlans)
            {
                string text = header.GetElementText().Trim();
                if (Regex.IsMatch(text ?? string.Empty, @"^(Till Bredband )(\d{1,4}|Bas|(100/10))$"))
                {
                    System.Console.WriteLine(text);
                    bredbandPlanTitle.Add(text);
                }                    
            }
            return bredbandPlanTitle;
        } 

        internal void CheckIfAddressSearchExist() => txtAddress.AssertElementPresent();
    }
}
