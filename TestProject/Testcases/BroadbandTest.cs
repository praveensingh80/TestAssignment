using TestProject.Pages;
using TestProject.Hooks;
using NUnit.Framework;
using System;

namespace TestProject.Steps
{
    public class BroadbandTest : HookInitialize
    {
        [Test]
        public void Should_See_Atleast_One_BredbandPlanTest()
        {
            NavigateSite();
            
            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().HandleGDPRCookiesPopUpIfExist();
            CurrentPage.As<HomePage>().ClickHandla();
            CurrentPage = CurrentPage.As<HomePage>().ClickBredbandsabonnemang();

            CurrentPage.As<BredbandPage>().CheckIfAddressSearchExist();
            CurrentPage.As<BredbandPage>().SearchBredbandPlanForAddress("Storgatan 1, Uppsala", "0001");

            Assert.AreNotEqual(CurrentPage.As<BredbandPage>().GetOfferedBredbandPlans().Count, 0);
        }
    }
}
