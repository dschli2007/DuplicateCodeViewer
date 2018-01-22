using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public class ViewController
    {
        private readonly IFileReaderFactory _fileReaderFactory;
        private Fragment _currentFragment;
        private Duplicate _currentDuplicate;

        private List<Line> _lines;
        private List<Line> _duplicateFileLines;

        public SourceFile CurrentFile { get; private set; }
        public Duplicate[] Duplicates { get; private set; }
        
        public ViewController(IFileReaderFactory fileReaderFactory)
        {
            _fileReaderFactory = fileReaderFactory;
        }

        public void SetContext(SourceFile sourceFile, Duplicate[] duplicates)
        {
            CurrentFile = sourceFile;
            Duplicates = duplicates;
        }

        public void SetCurrentFileLine(int lineNumber)
        {

        }

        public void SetCurrentDuplicateFile(SourceFile sourceFile)
        {

        }




    }
}
