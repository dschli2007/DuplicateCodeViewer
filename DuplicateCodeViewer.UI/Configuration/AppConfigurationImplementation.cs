using System.Configuration;

namespace DuplicateCodeViewer.UI.Configuration
{
    public class AppConfigurationImplementation : IAppConfiguration
    {
        private System.Configuration.Configuration _configFile;

        public AppConfigurationImplementation()
        {
            _configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }


        public string DupFinderExe
        {
            get
            {
                return _configFile.AppSettings.Settings["dupFinderExe"].Value;
            }
            set
            {
                var settings = _configFile.AppSettings.Settings;
                settings.Remove(@"dupFinderExe");
                settings.Add(@"dupFinderExe", value);
                _configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(_configFile.AppSettings.SectionInformation.Name);
            }
        }



    }
}
