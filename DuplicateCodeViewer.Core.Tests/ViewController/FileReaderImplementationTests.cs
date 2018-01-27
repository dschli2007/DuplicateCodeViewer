using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.Tests.Resources;
using DuplicateCodeViewer.Core.ViewController;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.ViewController
{
    [TestFixture]
    public class FileReaderImplementationTests
    {

        [Test]
        public void ReadLine_WhenCalled_ShouldReadOneFile()
        {
            using (var tempFile = ResourceHelper.CreateSourceFile(3, "Line{0}"))
            {
                var sourceFile = new SourceFile(tempFile.Filename);

                using (var obj = new FileReaderImplementation(sourceFile))
                {
                    Assert.AreEqual("Line1", obj.ReadLine());
                    Assert.AreEqual("Line2", obj.ReadLine());
                    Assert.AreEqual("Line3", obj.ReadLine());
                }
            }
        }

        [Test]
        public void CanRead_WhenNoLines_ShouldReturnFalse()
        {
            using (var tempFile = ResourceHelper.CreateSourceFile(1, "Line{0}"))
            {
                var sourceFile = new SourceFile(tempFile.Filename);

                using (var obj = new FileReaderImplementation(sourceFile))
                {
                    obj.ReadLine();
                    Assert.IsFalse(obj.CanRead);
                }
            }
        }

        [Test]
        public void CanRead_WhenHasLines_ShouldReturnTrue()
        {
            using (var tempFile = ResourceHelper.CreateSourceFile(1, "Line{0}"))
            {
                var sourceFile = new SourceFile(tempFile.Filename);

                using (var obj = new FileReaderImplementation(sourceFile))
                {
                    Assert.IsTrue(obj.CanRead);
                }
            }
        }

    }
}