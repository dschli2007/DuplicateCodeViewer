using System;
using System.Windows.Forms;
using DuplicateCodeViewer.UI.UserInterfaceCommands;

namespace DuplicateCodeViewer.UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void MnuQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MnuOpenXmlFile_Click(object sender, EventArgs e)
        {
            var command = new OpenXmlFileCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void MnuOpenProject_Click(object sender, EventArgs e)
        {
            var command = new OpenVisualStudioFileCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void MnuSelectDupFinderExe_Click(object sender, EventArgs e)
        {
            var command = new SelectDupFinderExeCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            var command = new ShowAboutCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }
    }
}
