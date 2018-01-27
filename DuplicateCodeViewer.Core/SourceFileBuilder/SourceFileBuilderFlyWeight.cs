using System.Collections.Generic;
using System.IO;
using System.Linq;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.SourceFileBuilder
{
    public class SourceFileBuilderFlyWeight : ISourceFileBuilderFlyWeight
    {
        private readonly string _relativeDirectory;
        private readonly Dictionary<string, SourceFile> _files = new Dictionary<string, SourceFile>();
        private readonly object _filesLock = new object();


        public SourceFileBuilderFlyWeight(string relativeDirectory)
        {
            _relativeDirectory = relativeDirectory;
            if (!_relativeDirectory.EndsWith(@"\"))
                _relativeDirectory += @"\";
        }

        public SourceFile GetSourceFile(string filename)
        {
            lock (_filesLock)
            {
                if (_files.ContainsKey(filename))
                    return _files[filename];

                var absoluteFilename = GetAbsoluteFilename(filename);
                var newFile = new SourceFile(absoluteFilename);
                _files[filename] = newFile;
                return newFile;
            }
        }

        private string GetAbsoluteFilename(string filename)
        {
            var result = Path.GetFullPath(_relativeDirectory + filename);
            return result;
        }

        public IEnumerable<SourceFile> GetAll()
        {
            lock (_filesLock)
            {
                return (from item in _files select item.Value).ToArray();
            }
        }
    }
}
