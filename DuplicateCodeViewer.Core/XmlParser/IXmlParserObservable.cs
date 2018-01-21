using System.Xml;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal interface IXmlParserObservable
    {
        void AddObserver(IXmlParserObserver observer);
        void RemoveObserver(IXmlParserObserver observer);
        void Notify(Duplicate duplicate);
        void Parse(XmlDocument document);
    }
}