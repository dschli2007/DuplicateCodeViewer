namespace DuplicateCodeViewer.Core.SourceFileBuilder
{
    internal static class SourceFileBuilderFactory
    {
        public static ISourceFileBuilderFlyWeight CreateInstance(string relativeDirectory)
        {
            var result = new SourceFileBuilderFlyWeight(relativeDirectory);
            return result;

        }

    }
}
