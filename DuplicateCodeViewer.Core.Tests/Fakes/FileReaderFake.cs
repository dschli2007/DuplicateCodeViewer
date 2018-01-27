using DuplicateCodeViewer.Core.ViewController;

namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    public class FileReaderFake : IFileReader
    {
        private readonly string[] _content;
        private int _index;

        public FileReaderFake(string[] content)
        {
            _content = content;
        }

        public bool CanRead => _index < _content.Length;

        public string ReadLine()
        {
            var result = _content[_index];
            _index++;
            return result;
        }

        public void Dispose()
        {

        }
    }
}
