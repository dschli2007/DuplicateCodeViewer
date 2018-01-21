using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.SourceFileBuilder
{
    public interface ISourceFileBuilderFlyWeight
    {
        SourceFile GetSourceFile(string filename);
        IEnumerable<SourceFile> GetAll();
    }
}