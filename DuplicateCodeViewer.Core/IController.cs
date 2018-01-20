using System;
using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core
{
    public interface IController
    {
        void Load(string filename);

        event EventHandler DataUpdated;

        IEnumerable<Duplicate> Duplicates { get; }

        IEnumerable<SourceFile> UniqueFiles { get; }
    }
}
