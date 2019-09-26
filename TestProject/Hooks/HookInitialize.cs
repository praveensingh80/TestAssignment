using Framework.Base;
using NUnit.Framework;

namespace TestProject.Hooks
{
    public class HookInitialize : TestInitializeHook
    { 
        [SetUp]
        public static void TestInitialize()
        {
            string testSettingName = "dev";//TestContext.Parameters.Get("testSettingName");
            InitializeSettings(testSettingName);
        }

        [TearDown]
        public void TestStop()
        {
            DriverContext.Driver.Quit();
        }
    }
}
