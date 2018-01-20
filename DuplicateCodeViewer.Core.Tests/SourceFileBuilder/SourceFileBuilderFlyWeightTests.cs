using DuplicateCodeViewer.Core.SourceFileBuilder;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.SourceFileBuilder
{
    [TestFixture]
    public class SourceFileBuilderFlyWeightTests
    {

        [TestCase("file1.txt")]
        [TestCase("file2.txt")]
        public void GetSourceFile_WhenSameFileName_ShoudReturnSameObject(string filename)
        {
            var builder = new SourceFileBuilderFlyWeight();
            var result1 = builder.GetSourceFile(filename);
            var result2 = builder.GetSourceFile(filename);
            Assert.AreSame(result1, result2);
        }

        [Test]
        public void GetSourceFile_WhenMultipleFiles_ShoudReturnSameObjectForAll()
        {
            var file1 = "a.txt";
            var file2 = "b.txt";
            var builder = new SourceFileBuilderFlyWeight();
            var result1 = builder.GetSourceFile(file1);
            var result2 = builder.GetSourceFile(file2);
            var result1A = builder.GetSourceFile(file1);
            var result2A = builder.GetSourceFile(file2);
            Assert.AreSame(result1, result1A);
            Assert.AreSame(result2, result2A);
        }
    }
}
