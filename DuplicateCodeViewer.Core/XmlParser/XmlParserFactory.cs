using DuplicateCodeViewer.Core.SourceFileFlyWeight;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal static class XmlParserFactory
    {
        public static XmlParserObservable CreateInstance(ISourceFileFlyWeight sourceFile)
        {
            var result = new XmlParserObservable(sourceFile);
            return result;
        }
    }

}
