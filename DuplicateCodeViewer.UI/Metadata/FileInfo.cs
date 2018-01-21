using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.UI.Metadata
{
    internal class FileInfo
    {
        public SourceFile SourceFile { get; set; }

        public int? LazyFragments { get; set; }

        public int? LazyCost { get; set; }

        public Duplicate[] LazyDuplicates { get; set; }
    }
}
