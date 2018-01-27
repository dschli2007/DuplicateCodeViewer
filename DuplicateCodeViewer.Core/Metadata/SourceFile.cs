namespace DuplicateCodeViewer.Core.Metadata
{
    public class SourceFile
    {
        public string Filename { get; set; }

        public SourceFile(string filename)
        {
            Filename = filename;
        }

        public override string ToString()
        {
            return Filename;
        }
    }
}
