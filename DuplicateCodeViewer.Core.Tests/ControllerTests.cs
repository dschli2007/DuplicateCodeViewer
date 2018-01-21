using System.IO;
using System.Linq;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests
{
    [TestFixture]
    public class ControllerTests
    {

        [Test]
        public void Load_WhenValidFile_ShouldLoadTheFile()
        {
            var filename = CreateXmlFile();
            try
            {
                var controller = new Controller();
                Assert.AreEqual(0, controller.Duplicates.Count());
                controller.Load(filename);
                Assert.IsTrue(controller.Duplicates.Any());
            }
            finally
            {
                File.Delete(filename);
            }
        }

        private string CreateXmlFile()
        {
            var filename = Path.GetTempFileName();

            const string resourceName = "DuplicateCodeViewer.Core.Tests.Resources.complete.xml";
            var stream = GetType().Assembly.GetManifestResourceStream(resourceName);
            try
            {
                using (var fs = new FileStream(filename, FileMode.Create))
                {
                    stream?.CopyTo(fs);
                }
            }
            finally
            {
                stream?.Dispose();
            }

            return filename;
        }
    }
}
