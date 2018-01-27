using System.Collections.Generic;
using System.Linq;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileFlyWeight;

namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    internal class SourceFileFlyWeightFake : ISourceFileFlyWeight
    {
        private readonly List<SourceFile> _allFiles = new List<SourceFile>();

        public SourceFile GetSourceFile(string filename)
        {
            var result = _allFiles.FirstOrDefault(f => f.Filename == filename);
            if (result != null)
                return result;

            result = new SourceFile(filename);
            _allFiles.Add(result);
            return result;
        }

        public IEnumerable<SourceFile> GetAll()
        {
            return _allFiles.ToArray();
        }
    }
}