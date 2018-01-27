using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.Tests.Resources;
using DuplicateCodeViewer.Core.ViewController;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.ViewController
{
    [TestFixture]
    public class FileReaderFactoryImplementationTests
    {

        [Test]
        public void CreateFileReader_WhenCalled_ShouldReturnOneFileReaderImplementation()
        {
            using (var tempFile = ResourceHelper.CreateSourceFile(1, ""))
            {
                var factory = new FileReaderFactoryImplementation();
                using (var obtained = factory.CreateFileReader(new SourceFile(tempFile.Filename )))
                {
                    Assert.AreSame(typeof(FileReaderImplementation), obtained.GetType());
                }
            }

        }
    }
}
