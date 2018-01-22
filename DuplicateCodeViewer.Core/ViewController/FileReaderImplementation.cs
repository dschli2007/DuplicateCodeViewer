using System.IO;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public sealed class FileReaderImplementation : IFileReader
    {
        private readonly StreamReader _innerReader;

        public FileReaderImplementation(SourceFile file)
        {
            _innerReader = new StreamReader(file.Filename);
        }

        public bool CanRead => _innerReader != null && !_innerReader.EndOfStream;

        public string ReadLine()
        {
            return _innerReader.ReadLine();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                _innerReader?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}