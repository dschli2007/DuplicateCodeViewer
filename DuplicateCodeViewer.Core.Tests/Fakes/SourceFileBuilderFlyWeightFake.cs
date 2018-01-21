using System.Collections.Generic;
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

        public IEnumerable<SourceFile> GetAll()
        {
            return new[] { GetSourceFile("any.txt") };
        }
    }
}