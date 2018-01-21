namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    internal class XmlFileSourceFake: IXmlFileSource  
    {
        public XmlFileSourceFake(string filename)
        {
            Filename = filename;
        }

        public string Filename { get; }
    }
}
