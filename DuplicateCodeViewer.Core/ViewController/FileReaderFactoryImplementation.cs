using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public class FileReaderFactoryImplementation : IFileReaderFactory
    {
        public IFileReader CreateFileReader(SourceFile file)
        {
            return new FileReaderImplementation(file);
        }
    }
}
