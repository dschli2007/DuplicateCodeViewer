using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.XmlParser
{
    public interface IXmlParserObserver
    {
        void DuplicateParsed(Duplicate duplicate);
    }
}
