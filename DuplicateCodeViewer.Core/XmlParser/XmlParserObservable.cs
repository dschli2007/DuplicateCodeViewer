using System.Collections.Generic;
using System.Xml;
using System.Linq;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.SourceFileFlyWeight;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal class XmlParserObservable : IXmlParserObservable
    {
        private readonly ISourceFileFlyWeight _sourceFile;
        private readonly List<IXmlParserObserver> _observers = new List<IXmlParserObserver>();
        private readonly object _observersLock = new object();

        public XmlParserObservable(ISourceFileFlyWeight sourceFile)
        {
            _sourceFile = sourceFile;
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
                    Fragments = (from item in nodeReader.Fragments select new Fragment
                    {
                        SourceFile = _sourceFile.GetSourceFile(item.Filename),
                        LineStart = item.LineStart,
                        LineEnd = item.LineEnd

                    }).ToArray()
                };
                Notify(newDuplicate);
            }
        }
    }
}
