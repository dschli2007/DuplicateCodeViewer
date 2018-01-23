using System.Windows.Forms;
using DuplicateCodeViewer.UI.Configuration;

namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal class SelectDupFinderExeCommand : IUserInterfaceCommand
    {
        public void Execute()
        {
            var openFile = new OpenFileDialog {Filter = @"DupFinder.exe|DupFinder.exe"};
            var dialogResult = openFile.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var appConfig = new AppConfigurationImplementation();
                appConfig.DupFinderExe = openFile.FileName;
            }
        }
    }
}