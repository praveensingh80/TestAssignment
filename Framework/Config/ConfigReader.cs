using Framework.Base;
using System;

namespace Framework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings(string testSettingName)
        {
            Settings.AUT = TestConfiguration.Settings.TestSettings[testSettingName].AUT;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), TestConfiguration.Settings.TestSettings[testSettingName].Browser);
            Settings.TestType = TestConfiguration.Settings.TestSettings[testSettingName].TestType;
            Settings.IsLog = TestConfiguration.Settings.TestSettings[testSettingName].IsLog;
            Settings.LogPath = TestConfiguration.Settings.TestSettings[testSettingName].LogPath;
        }
    }
}
