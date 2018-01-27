using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.Tests.Resources;
using DuplicateCodeViewer.Core.ViewController;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.ViewController
{
    [TestFixture]
    public class InternalFileLinesReaderTests
    {

        [Test]
        public void ReadLines_WhenCalled_ShouldReturnFileLines()
        {
            using (var tempFile = ResourceHelper.CreateSourceFile(3, "Line{0}"))
            {
                var sourceFile = new SourceFile(tempFile.Filename);
                var obj = new InternalFileLinesReader(
                    new FileReaderFactoryImplementation(),
                    sourceFile,
                    new Duplicate[0]);

                var obtained = obj.ReadLines();
                Assert.AreEqual(3, obtained.Count);
                Assert.AreEqual("Line1", obtained[0].Content);
                Assert.AreEqual("Line2", obtained[1].Content);
                Assert.AreEqual("Line3", obtained[2].Content);
            }
        }

        [Test]
        public void UpdateDuplicateInLines_WhenDuplicatesInfile_ShouldSetDuplicateInLine()
        {
            using (var tempFile = ResourceHelper.CreateSourceFile(4, "Line{0}"))
            {
                var sourceFile = new SourceFile(tempFile.Filename);
                var duplicate = new Duplicate
                {
                    Fragments = new[]
                    {
                        new Fragment
                        {
                            SourceFile = sourceFile,
                            LineStart = 2,
                            LineEnd = 3
                        }
                    }
                };

                var obj = new InternalFileLinesReader(
                    new FileReaderFactoryImplementation(),
                    sourceFile,
                    new[] { duplicate });

                var obtained = obj.ReadLines();

                Assert.IsNull(obtained[0].Duplicate);
                Assert.IsNotNull(obtained[1].Duplicate);
                Assert.IsNotNull(obtained[2].Duplicate);
                Assert.IsNull(obtained[3].Duplicate);
            }
        }



    }
}