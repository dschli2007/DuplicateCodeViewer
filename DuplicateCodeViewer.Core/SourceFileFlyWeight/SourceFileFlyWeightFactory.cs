namespace DuplicateCodeViewer.Core.SourceFileFlyWeight
{
    internal static class SourceFileFlyWeightFactory
    {
        public static ISourceFileFlyWeight CreateInstance(string relativeDirectory)
        {
            var result = new SourceFileFlyWeight(relativeDirectory);
            return result;

        }

    }
}
