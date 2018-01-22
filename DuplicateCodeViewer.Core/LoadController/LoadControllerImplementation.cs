using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileBuilder;

namespace DuplicateCodeViewer.Core.LoadController
{
    public class LoadControllerImplementation : ILoadController
    {
        private readonly object _dataLock = new object();
        private List<Duplicate> _duplicates = new List<Duplicate>();
        private List<SourceFile> _uniqueFiles = new List<SourceFile>();

        public void LoadAsync(IXmlFileSource source)
        {
            InternalLoad(source.Filename, true);    
        }

        public void Load(IXmlFileSource source)
        {
            InternalLoad(source.Filename, false);
        }

        private void InternalLoad(string filename, bool async)
        {
            var document = new XmlDocument();
            document.Load(filename);
            var relativeDirectory = Path.GetDirectoryName(filename);
            var sourceFileBuilder = SourceFileBuilderFactory.CreateInstance(relativeDirectory);

            var loader = new InternalXmlParserObserver(sourceFileBuilder, document, LoaderComplete);
            loader.Async = async;
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

        private void LoaderComplete(InternalXmlParserObserver internalXmlParserObserver)
        {
            lock (_dataLock)
            {
                _duplicates = internalXmlParserObserver.Duplicates.ToList();
                _uniqueFiles = internalXmlParserObserver.UniqueSourceFiles.ToList();
            }
            LoadCompleted?.Invoke(this, EventArgs.Empty);
        }


    }
}