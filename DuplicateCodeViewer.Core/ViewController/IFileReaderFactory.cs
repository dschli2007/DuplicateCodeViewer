using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public interface IFileReaderFactory
    {
        IFileReader CreateFileReader(SourceFile file);
    }
}
