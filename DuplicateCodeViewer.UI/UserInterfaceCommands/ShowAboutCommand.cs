using DuplicateCodeViewer.UI.Forms;

namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal class ShowAboutCommand : IUserInterfaceCommand
    {
        public void Execute()
        {
            using (var formAbout = new FormAbout())
            {
                formAbout.ShowDialog();
            }
        }
    }
}