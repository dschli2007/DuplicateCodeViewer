namespace DuplicateCodeViewer.Core
{
    public interface IXmlFileSource
    {
        bool CanLoad { get; }

        string Filename { get; }
    }
}
