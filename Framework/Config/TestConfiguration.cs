using System.Configuration;

namespace Framework.Config
{
    public class TestConfiguration : ConfigurationSection
    {
        private static TestConfiguration _testConfig = (TestConfiguration)ConfigurationManager.GetSection("TestProjectConfiguration");

        public static TestConfiguration Settings { get { return _testConfig; } }

        [ConfigurationProperty("testSettings")]
        public FrameworkElementCollection TestSettings { get { return (FrameworkElementCollection)base["testSettings"]; } }


    }
}
