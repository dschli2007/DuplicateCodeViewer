namespace DuplicateCodeViewer.Core.ViewController
{
    public interface IFileReader
    {
        bool CanRead { get; }
        string ReadLine();
    }
}
