using System.Windows.Forms;
using DuplicateCodeViewer.Core;
using DuplicateCodeViewer.Core.LoadController;

namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal class OpenXmlFileCommand : IUserInterfaceCommand, IXmlFileSource
    {
        public void Execute()
        {
            var openFile = new OpenFileDialog();
            var dialogResult = openFile.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Filename = openFile.FileName;
                CanLoad = true;
            }
        }

        public bool CanLoad { get; private set; }

        public string Filename { get; private set; }
    }
}