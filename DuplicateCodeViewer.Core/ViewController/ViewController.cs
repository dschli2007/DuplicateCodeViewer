using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public class ViewController
    {
        private Fragment _currentFragment;
        private Duplicate _currentDuplicate;

        private List<Line> _lines;
        private List<Line> _duplicateFileLines;

        public SourceFile CurrentFile { get; private set; }
        public Duplicate[] Duplicates { get; private set; }

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
