namespace DuplicateCodeViewer.Core.LoadController
{
    public interface IXmlFileSource
    {
        bool CanLoad { get; }

        string Filename { get; }
    }
}
