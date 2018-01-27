using System.Linq;
using DuplicateCodeViewer.Core.LoadController;
using DuplicateCodeViewer.Core.Tests.Fakes;
using DuplicateCodeViewer.Core.Tests.Resources;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.LoadController
{
    [TestFixture]
    public class LoadControllerImplementationTests
    {

        [Test]
        public void Load_WhenValidFile_ShouldLoadTheFile()
        {
            using (var tempFile = ResourceHelper.CreateXmlFile())
            {
                var controller = new LoadControllerImplementation();
                Assert.AreEqual(0, controller.Duplicates.Count());
                controller.Load(new XmlFileSourceFake(tempFile.Filename));
                Assert.IsTrue(controller.Duplicates.Any());
                Assert.AreEqual(6, controller.UniqueFiles.Count());
            }
        }

        [Test]
        public void LoadAsync_WhenValidFile_ShouldLoadTheFileAsynchronous()
        {
            using (var tempFile = ResourceHelper.CreateXmlFile())
            {
                var completed = false;
                var locker = new object();
                var controller = new LoadControllerImplementation();
                Assert.AreEqual(0, controller.Duplicates.Count());
                controller.LoadCompleted += (sender, args) => { lock (locker) { completed = true; } };
                controller.LoadAsync(new XmlFileSourceFake(tempFile.Filename));
                while (true)
                {
                    lock (locker)
                    {
                        if (completed) break;
                    }
                }
                Assert.IsTrue(controller.Duplicates.Any());
                Assert.AreEqual(6, controller.UniqueFiles.Count());
            }
            
        }


    }
}
