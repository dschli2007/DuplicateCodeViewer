using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.SourceFileFlyWeight
{
    public interface ISourceFileFlyWeight
    {
        SourceFile GetSourceFile(string filename);
        IEnumerable<SourceFile> GetAll();
    }
}