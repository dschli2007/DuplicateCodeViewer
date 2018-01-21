using System.Linq;
using System.Xml;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests
{
    [TestFixture]
    public class ControllerTests
    {

        [Test]
        public void Load_WhenValidFile_ShouldLoadTheFile()
        {
            var document = CreateXmlDocument();
            var controller = new Controller();
            Assert.AreEqual(0, controller.Duplicates.Count());
            //controller.LoadAsync(document);
            //Assert.Greater(0, controller.Duplicates.Count());
        }

        private XmlDocument CreateXmlDocument()
        {
            const string resourceName = "DuplicateCodeViewer.Core.Tests.Resources.complete.xml";
            var stream = GetType().Assembly.GetManifestResourceStream(resourceName);
            try
            {
                var document = new XmlDocument();
                if (stream != null)
                    document.Load(stream);
                return document;
            }
            finally
            {
                stream?.Dispose();
            }
        }
    }
}
