using DuplicateCodeViewer.Core.LoadController;

namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    internal class XmlFileSourceFake : IXmlFileSource
    {
        public XmlFileSourceFake(string filename)
        {
            Filename = filename;
        }

        public bool CanLoad { get; } = true;
        public string Filename { get; }
    }
}
