using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileBuilder;
using DuplicateCodeViewer.Core.XmlParser;

namespace DuplicateCodeViewer.Core
{
    internal class Loader : IXmlParserObserver
    {
        private readonly ISourceFileBuilderFlyWeight _sourceFileBuilder;
        private readonly XmlDocument _document;
        private readonly Action<Loader> _completeCallback;

        private List<Duplicate> _duplicates;
        private IXmlParserObservable _xmlParserObservable;

        public bool Async { get; set; }

        public Loader(ISourceFileBuilderFlyWeight sourceFileBuilder, XmlDocument document, Action<Loader> completeCallback)
        {
            _sourceFileBuilder = sourceFileBuilder;
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
            _xmlParserObservable = XmlParserFactory.CreateInstance(_sourceFileBuilder);
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

        public IEnumerable<SourceFile> UniqueSourceFiles => _sourceFileBuilder.GetAll();

    }
}
