using System.Configuration;

namespace DuplicateCodeViewer.UI.Configuration
{
    public class AppConfigurationImplementation : IAppConfiguration
    {
        
        public string DupFinderExe
        {
            get => ConfigurationManager.AppSettings["dupFinderExe"];
            set => ConfigurationManager.AppSettings["dupFinderExe"] = value;
        }
        
    }
}
