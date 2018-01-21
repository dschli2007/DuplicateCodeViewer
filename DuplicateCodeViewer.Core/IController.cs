using System;
using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core
{
    public interface IController
    {
        void Load(IXmlFileSource  source);

        void LoadAsync(IXmlFileSource source);

        event EventHandler LoadCompleted;

        IEnumerable<Duplicate> Duplicates { get; }

        IEnumerable<SourceFile> UniqueFiles { get; }
    }
}
