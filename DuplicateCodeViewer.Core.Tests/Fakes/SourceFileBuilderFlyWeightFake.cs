using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileBuilder;

namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    internal class SourceFileBuilderFlyWeightFake : ISourceFileBuilderFlyWeight
    {
        public SourceFile GetSourceFile(string filename)
        {
            return new SourceFile { Filename = filename };
        }
    }
}