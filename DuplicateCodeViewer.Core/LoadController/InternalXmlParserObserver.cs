using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileFlyWeight;
using DuplicateCodeViewer.Core.XmlParser;

namespace DuplicateCodeViewer.Core.LoadController
{
    internal class InternalXmlParserObserver : IXmlParserObserver
    {
        private readonly ISourceFileFlyWeight _sourceFile;
        private readonly XmlDocument _document;
        private readonly Action<InternalXmlParserObserver> _completeCallback;

        private List<Duplicate> _duplicates;
        private IXmlParserObservable _xmlParserObservable;

        public bool Async { get; set; }

        public InternalXmlParserObserver(ISourceFileFlyWeight sourceFile, XmlDocument document, Action<InternalXmlParserObserver> completeCallback)
        {
            _sourceFile = sourceFile;
            _document = document;
            _completeCallback = completeCallback;
        }

        public void Execute()
        {
            if (Async)
            {
                var thread = new Thread(Work);
                thread.Start();
            }
            else
            {
                Work();
            }
        }

        private void Work()
        {
            _duplicates = new List<Duplicate>();
            _xmlParserObservable = XmlParserFactory.CreateInstance(_sourceFile);
            _xmlParserObservable.AddObserver(this);
            _xmlParserObservable.Parse(_document);
            _completeCallback?.Invoke(this);
        }

        public void DuplicateParsed(Duplicate duplicate)
        {
            _duplicates.Add(duplicate);
        }

        public IEnumerable<Duplicate> Duplicates
        {
            get
            {
                foreach (var duplicate in _duplicates)
                {
                    yield return duplicate;
                }
            }
        }

        public IEnumerable<SourceFile> UniqueSourceFiles => _sourceFile.GetAll();

    }
}
