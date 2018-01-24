using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.LoadController;
using DuplicateCodeViewer.UI.Configuration;

namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal class OpenVisualStudioFileCommand : IUserInterfaceCommand, IXmlFileSource
    {
        public void Execute()
        {
            string file;
            if (TryToPickFile(out file))
            {
                Filename = CreateDuplicateReportFile(file);
                CanLoad = true;
            }
        }

        private string CreateDuplicateReportFile(string file)
        {
            var temp = Path.Combine(Environment.CurrentDirectory, Path.GetFileNameWithoutExtension(file) + ".xml");

            var config = new AppConfigurationImplementation();
            var exe = config.DupFinderExe;
            var parameters = $"-o:{temp} {file}";
            var process = Process.Start(exe, parameters);
            process?.WaitForExit();
            
            return temp;
        }

        private bool TryToPickFile(out string file)
        {
            var openFile = new OpenFileDialog { Filter = @"Solution|*.sln|Project|*.csproj" };
            var dialogResult = openFile.ShowDialog();
            file = openFile.FileName;
            return dialogResult == DialogResult.OK;
        }

        public bool CanLoad { get; private set; }

        public string Filename { get; private set; }
    }
}