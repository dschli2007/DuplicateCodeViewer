namespace DuplicateCodeViewer.Core.ViewController
{
    public interface IFileReaderFactory
    {
        IFileReader CreateFileReader(string filename);
    }
}
