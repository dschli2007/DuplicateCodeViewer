using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.XmlFileParser
{
    public interface IXmlParserObserver
    {
        void DuplicateParsed(Duplicate duplicate);
    }
}
