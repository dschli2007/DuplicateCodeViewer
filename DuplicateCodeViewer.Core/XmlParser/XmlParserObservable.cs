using System.Collections.Generic;
using System.Xml;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileBuilder;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal class XmlParserObservable
    {
        private readonly ISourceFileBuilderFlyWeight _sourceFileBuilder;
        private readonly List<IXmlParserObserver> _observers = new List<IXmlParserObserver>();
        private readonly object _observersLock = new object();

        public XmlParserObservable(ISourceFileBuilderFlyWeight sourceFileBuilder)
        {
            _sourceFileBuilder = sourceFileBuilder;
        }

        public void AddObserver(IXmlParserObserver observer)
        {
            lock (_observersLock)
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IXmlParserObserver observer)
        {
            lock (_observersLock)
            {
                _observers.Remove(observer);
            }
        }

        public void Notify(Duplicate duplicate)
        {
            lock (_observersLock)
            {
                foreach (var observer in _observers)
                {
                    observer.DuplicateParsed(duplicate);
                }
            }
        }

        public void Parse(XmlDocument document)
        {
            var nodeReader = new DuplicateXmlNodeReader();
            foreach (XmlNode node in document.GetElementsByTagName("Duplicate"))
            {
                nodeReader.Read(node);
                var newDuplicate = new Duplicate
                {
                    Cost = nodeReader.Cost,
                    Fragment1 = new Fragment
                    {
                        SourceFile = _sourceFileBuilder.GetSourceFile(nodeReader.Fragment1.Filename),
                        LineStart = nodeReader.Fragment1.LineStart,
                        LineEnd = nodeReader.Fragment1.LineEnd

                    },
                    Fragment2 = new Fragment
                    {
                        SourceFile = _sourceFileBuilder.GetSourceFile(nodeReader.Fragment2.Filename),
                        LineStart = nodeReader.Fragment2.LineStart,
                        LineEnd = nodeReader.Fragment2.LineEnd
                    }
                };
                Notify(newDuplicate);
            }
        }
    }
}
