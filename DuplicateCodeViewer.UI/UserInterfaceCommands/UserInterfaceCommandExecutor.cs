using DuplicateCodeViewer.Core.LoadController;

namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal static class UserInterfaceCommandExecutor
    {

        public static ILoadController Controller { get; set; }

        public static void Execute(IUserInterfaceCommand command)
        {
            command.Execute();

            var sourceFile = command as IXmlFileSource;
            if (sourceFile != null && sourceFile.CanLoad)
                Controller.LoadAsync(sourceFile);
        }
    }
}
