using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.SourceFileBuilder
{
    public class SourceFileBuilderFlyWeight : ISourceFileBuilderFlyWeight
    {
        private readonly Dictionary<string, SourceFile> _files = new Dictionary<string, SourceFile>();   
        private readonly object _filesLock = new object();
        
        public SourceFile GetSourceFile(string filename)
        {
            lock (_filesLock)
            {
                if (_files.ContainsKey(filename))
                    return _files[filename];

                var newFile = new SourceFile{ Filename = filename};
                _files[filename] = newFile;
                return newFile;
            }
        }
    }
}
