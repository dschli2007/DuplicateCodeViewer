using System;
using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core
{
    public class Controller : IController
    {
        public void Load(string filename)
        {
            throw new NotImplementedException();
        }

        public event EventHandler DataUpdated;

        public IEnumerable<Duplicate> Duplicates { get; }

        public IEnumerable<SourceFile> UniqueFiles { get; }
    }
}