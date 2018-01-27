using System;
using System.Collections.Generic;
using System.Linq;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public class ViewController
    {
        private readonly IFileReaderFactory _fileReaderFactory;
        private Fragment _currentFragment;
        private Duplicate _currentDuplicate;
        private List<Line> _lines;

        private SourceFile _currentFile;
        private Duplicate[] _duplicates;

        public ViewController(IFileReaderFactory fileReaderFactory)
        {
            _fileReaderFactory = fileReaderFactory;
        }

        public void SetContext(SourceFile sourceFile, Duplicate[] duplicates)
        {
            _currentFile = sourceFile;
            _duplicates = duplicates;
            InternalUpdateFileLines();
        }

        private void InternalUpdateFileLines()
        {
            _lines = GetLinesFromFile(_currentFile, _duplicates);
            OnUpdateFileLines?.Invoke(this, _lines);
        }

        public void SetCurrentFileLine(int lineNumber)
        {
            if (_lines == null || lineNumber >= _lines.Count)
                return;

            var fragment = GetFragmentFromLine(lineNumber);
            if (fragment != _currentFragment)
            {
                SetCurrentDuplicateAndFragment(_lines[lineNumber - 1].Duplicate, fragment);
            }
        }

        public void SetCurrentDuplicateFile(SourceFile sourceFile)
        {
            var duplicatesToConsider = BuildDuplicateToCurrentDuplicatedFile();
            var lines = sourceFile == null ? new List<Line>() : GetLinesFromFile(sourceFile, duplicatesToConsider);
            OnUpdateDuplicateFileLines?.Invoke(this, lines);
        }

        private Duplicate[] BuildDuplicateToCurrentDuplicatedFile()
        {
            if (_currentDuplicate == null)
                return new Duplicate[0];
            
            var clone = new Duplicate
            {
                Cost = _currentDuplicate.Cost,
                Fragments = _currentDuplicate.Fragments.Where(f => f != _currentFragment).ToArray()
            };
            return new[] { clone };
        }

        private void SetCurrentDuplicateAndFragment(Duplicate duplicate, Fragment fragment)
        {
            _currentDuplicate = duplicate;
            _currentFragment = fragment;

            InternalUpdateDuplicateFiles();
        }

        private void InternalUpdateDuplicateFiles()
        {
            var list = new List<SourceFile>();
            if (_currentFragment != null)
            {
                list.AddRange((from item in _currentDuplicate.Fragments
                              where item != _currentFragment
                              select item.SourceFile).Distinct());
            }
            OnUpdateDuplicateFiles?.Invoke(this, list);
            if (list.Count == 0)
                OnUpdateDuplicateFileLines?.Invoke(this, new List<Line>());
        }

        private Fragment GetFragmentFromLine(int lineNumber)
        {
            var line = _lines[lineNumber - 1];
            if (line.Duplicate == null)
                return null;

            var fragment = line.Duplicate.Fragments.FirstOrDefault(f => f.SourceFile == _currentFile && lineNumber >= f.LineStart && lineNumber <= f.LineEnd);
            return fragment;
        }

        private List<Line> GetLinesFromFile(SourceFile file, Duplicate[] duplicates)
        {
            if (file != null)
            {
                var reader = new InternalFileLinesReader(_fileReaderFactory, file, duplicates);
                return reader.ReadLines();
            }
            return new List<Line>();
        }

        public event EventHandler<IList<Line>> OnUpdateFileLines;
        public event EventHandler<IList<SourceFile>> OnUpdateDuplicateFiles;
        public event EventHandler<IList<Line>> OnUpdateDuplicateFileLines;

    }
}
