using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.ViewController;

namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    public class FileReaderFactoryFake : IFileReaderFactory
    {
        public Dictionary<string, string[]> FileContents = new Dictionary<string, string[]>();

        public IFileReader CreateFileReader(SourceFile file)
        {
            
            var content = FileContents.ContainsKey(file.Filename) ? FileContents[file.Filename] : new string[0];

            return new FileReaderFake(content);
        }
    }
}
