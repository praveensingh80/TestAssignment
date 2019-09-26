using OpenQA.Selenium;
using Framework.Base;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T,bool> condition, int timeout)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeout)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }        

        private static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
