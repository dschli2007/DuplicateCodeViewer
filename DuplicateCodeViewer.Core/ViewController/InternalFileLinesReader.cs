using System.Collections.Generic;
using System.Linq;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.ViewController
{
    public class InternalFileLinesReader
    {
        private readonly IFileReaderFactory _factory;
        private readonly SourceFile _file;
        private readonly Duplicate[] _duplicates;

        public InternalFileLinesReader(IFileReaderFactory factory, SourceFile file, Duplicate[] duplicates)
        {
            _factory = factory;
            _file = file;
            _duplicates = duplicates;
        }

        public List<Line> ReadLines()
        {
            var lines = new List<Line>();
            using (var reader = _factory.CreateFileReader(_file))
            {
                while (reader.CanRead)
                {
                    lines.Add(new Line { Content = reader.ReadLine() });
                }
            }
            UpdateDuplicateInLines(lines);
            return lines;
        }

        private void UpdateDuplicateInLines(List<Line> lines)
        {
            if (_duplicates.Length == 0)
                return;

            foreach (var duplicate in _duplicates)
            {
                var fragment = duplicate.Fragments.FirstOrDefault(f => f.SourceFile == _file);
                if (fragment != null)
                {
                    for (var i = fragment.LineStart - 1; i < fragment.LineEnd; i++)
                    {
                        lines[i].Duplicate = duplicate;
                    }
                }
            }
        }
    }
}