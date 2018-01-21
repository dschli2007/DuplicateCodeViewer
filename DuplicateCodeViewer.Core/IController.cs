using System;
using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core
{
    public interface IController
    {
        void Load(string filename);

        void LoadAsync(string filename);

        event EventHandler LoadCompleted;

        IEnumerable<Duplicate> Duplicates { get; }

        IEnumerable<SourceFile> UniqueFiles { get; }
    }
}
