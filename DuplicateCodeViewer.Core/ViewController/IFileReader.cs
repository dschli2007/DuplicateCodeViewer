using System;

namespace DuplicateCodeViewer.Core.ViewController
{
    public interface IFileReader : IDisposable
    {
        bool CanRead { get; }
        string ReadLine();
    }
}
