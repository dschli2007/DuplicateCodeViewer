using DuplicateCodeViewer.Core.SourceFileBuilder;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.SourceFileBuilder
{
    [TestFixture]
    public class SourceFileBuilderFlyWeightTests
    {

        private static ISourceFileBuilderFlyWeight CreateBuilder()
        {
            return new SourceFileBuilderFlyWeight(@"c:\temp");
        }

        [TestCase("file1.txt")]
        [TestCase("file2.txt")]
        public void GetSourceFile_WhenSameFileName_ShoudReturnSameObject(string filename)
        {
            var builder = CreateBuilder();
            var result1 = builder.GetSourceFile(filename);
            var result2 = builder.GetSourceFile(filename);
            Assert.AreSame(result1, result2);
        }

        [Test]
        public void GetSourceFile_WhenMultipleFiles_ShoudReturnSameObjectForAll()
        {
            var file1 = "a.txt";
            var file2 = "b.txt";
            var builder = CreateBuilder();
            var result1 = builder.GetSourceFile(file1);
            var result2 = builder.GetSourceFile(file2);
            var result1A = builder.GetSourceFile(file1);
            var result2A = builder.GetSourceFile(file2);
            Assert.AreSame(result1, result1A);
            Assert.AreSame(result2, result2A);
        }

        [TestCase(@"c:\temp", @"..\test.txt", @"c:\test.txt")]
        [TestCase(@"c:\temp", @"test.txt", @"c:\temp\test.txt")]
        [TestCase(@"c:\temp\temp2", @"..\..\test.txt", @"c:\test.txt")]
        [TestCase(@"c:\temp\temp2\", @"..\..\test.txt", @"c:\test.txt")]
        public void GetSourceFile_WhenRelativeDirectory_ShouldSetAbsolutePathToFile(string relativeDirectory,
            string filename, string expectedFilename)
        {
            var builder = new SourceFileBuilderFlyWeight(relativeDirectory);
            var file = builder.GetSourceFile(filename);
            var filenameObtained = file.Filename;
            Assert.AreEqual(expectedFilename, filenameObtained);
        }

    }
}
