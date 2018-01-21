namespace DuplicateCodeViewer.Core.Metadata
{
    public class SourceFile
    {
        public string Filename { get; set; }

        public override string ToString()
        {
            return Filename;
        }
    }
}
