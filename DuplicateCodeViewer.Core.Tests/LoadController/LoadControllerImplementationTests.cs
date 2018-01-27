using System.IO;
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
            var filename = ResourceHelper.CreateXmlFile();
            try
            {
                var controller = new LoadControllerImplementation();
                Assert.AreEqual(0, controller.Duplicates.Count());
                controller.Load(new XmlFileSourceFake(filename));
                Assert.IsTrue(controller.Duplicates.Any());
                Assert.AreEqual(6, controller.UniqueFiles.Count());
            }
            finally
            {
                File.Delete(filename);
            }
        }

        [Test]
        public void LoadAsync_WhenValidFile_ShouldLoadTheFileAsynchronous()
        {
            var filename = ResourceHelper.CreateXmlFile();
            try
            {
                var completed = false;
                var locker = new object();
                var controller = new LoadControllerImplementation();
                Assert.AreEqual(0, controller.Duplicates.Count());
                controller.LoadCompleted += (sender, args) => { lock (locker) { completed = true; } };
                controller.LoadAsync(new XmlFileSourceFake(filename));
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
            finally
            {
                File.Delete(filename);
            }
        }


    }
}
