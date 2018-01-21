using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.UI.Metadata
{
    internal class LineInfo
    {
        public int LineNumber { get; set; }

        public string Content { get; set; }

        public Duplicate Duplicate { get; set; }
    }
}
