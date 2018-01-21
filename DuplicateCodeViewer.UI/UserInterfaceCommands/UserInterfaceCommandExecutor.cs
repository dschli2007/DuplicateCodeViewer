using DuplicateCodeViewer.Core;

namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal static class UserInterfaceCommandExecutor
    {

        public static IController Controller { get; set; }

        public static void Execute(IUserInterfaceCommand command)
        {
            command.Execute();

            var sourceFile = command as IXmlFileSource;
            if (sourceFile != null && sourceFile.CanLoad)
                Controller.LoadAsync(sourceFile);
        }
    }
}
