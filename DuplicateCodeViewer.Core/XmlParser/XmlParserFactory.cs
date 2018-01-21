using DuplicateCodeViewer.Core.SourceFileBuilder;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal static class XmlParserFactory
    {
        public static XmlParserObservable CreateInstance(ISourceFileBuilderFlyWeight sourceFileBuilder)
        {
            var result = new XmlParserObservable(sourceFileBuilder);
            return result;
        }
    }

}
