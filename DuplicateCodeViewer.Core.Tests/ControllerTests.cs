using System.IO;
using System.Linq;
using DuplicateCodeViewer.Core.LoadController;
using DuplicateCodeViewer.Core.Tests.Fakes;
using DuplicateCodeViewer.Core.Tests.Resources;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests
{
    [TestFixture]
    public class ControllerTests
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
            }
            finally
            {
                File.Delete(filename);
            }
        }
       
    }
}
