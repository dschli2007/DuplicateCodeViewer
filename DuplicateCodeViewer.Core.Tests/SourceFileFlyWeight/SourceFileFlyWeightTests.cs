using DuplicateCodeViewer.Core.SourceFileFlyWeight;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.SourceFileFlyWeight
{
    [TestFixture]
    public class SourceFileFlyWeightTests
    {

        private static ISourceFileFlyWeight CreateTestedObject()
        {
            return new Core.SourceFileFlyWeight.SourceFileFlyWeight(@"c:\temp");
        }

        [TestCase("file1.txt")]
        [TestCase("file2.txt")]
        public void GetSourceFile_WhenSameFileName_ShoudReturnSameObject(string filename)
        {
            var obj = CreateTestedObject();
            var result1 = obj.GetSourceFile(filename);
            var result2 = obj.GetSourceFile(filename);
            Assert.AreSame(result1, result2);
        }

        [Test]
        public void GetSourceFile_WhenMultipleFiles_ShoudReturnSameObjectForAll()
        {
            var file1 = "a.txt";
            var file2 = "b.txt";
            var obj = CreateTestedObject();
            var result1 = obj.GetSourceFile(file1);
            var result2 = obj.GetSourceFile(file2);
            var result1A = obj.GetSourceFile(file1);
            var result2A = obj.GetSourceFile(file2);
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
            var obj = new Core.SourceFileFlyWeight.SourceFileFlyWeight(relativeDirectory);
            var file = obj.GetSourceFile(filename);
            var filenameObtained = file.Filename;
            Assert.AreEqual(expectedFilename, filenameObtained);
        }

    }
}
