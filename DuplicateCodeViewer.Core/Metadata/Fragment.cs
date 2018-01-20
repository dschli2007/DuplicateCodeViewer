namespace DuplicateCodeViewer.Core.Metadata
{
    public class Fragment
    {
        public SourceFile SourceFile { get; set; }
        public int LineStart { get; set; }
        public int LineEnd { get; set; }
    }
}