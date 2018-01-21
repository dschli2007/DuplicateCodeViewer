namespace DuplicateCodeViewer.UI.UserInterfaceCommands
{
    internal static class UserInterfaceCommandExecutor
    {
        public static void Execute(IUserInterfaceCommand command)
        {
            command.Execute();
        }
    }
}
