using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileBuilder;

namespace DuplicateCodeViewer.Core
{
    public class Controller : IController
    {
        private readonly object _dataLock = new object();
        private List<Duplicate> _duplicates = new List<Duplicate>();
        private List<SourceFile> _uniqueFiles = new List<SourceFile>();

        public void LoadAsync(string filename)
        {
            var document = new XmlDocument();
            document.Load(filename);
            var relativeDirectory = Path.GetDirectoryName(filename);
            var sourceFileBuilder = SourceFileBuilderFactory.CreateInstance(relativeDirectory);

            var loader = new Loader(sourceFileBuilder, document, LoaderComplete);
            loader.Execute();
        }

        public event EventHandler LoadCompleted;

        public IEnumerable<Duplicate> Duplicates
        {
            get
            {
                lock (_dataLock)
                {
                    return _duplicates.ToList();
                }
            }
        }

        public IEnumerable<SourceFile> UniqueFiles
        {
            get
            {
                lock (_dataLock)
                {
                    return _uniqueFiles.ToList();
                }
            }
        }

        private void LoaderComplete(Loader loader)
        {
            lock (_dataLock)
            {
                _duplicates = loader.Duplicates.ToList();
                _uniqueFiles = loader.UniqueSourceFiles.ToList();
            }
            LoadCompleted?.Invoke(this, EventArgs.Empty);
        }


    }
}