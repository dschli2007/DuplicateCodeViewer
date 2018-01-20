using System.Collections.Generic;
using System.Xml;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal class XmlParserObservable
    {
        private readonly List<IXmlParserObserver> _observers = new List<IXmlParserObserver>();
        private readonly object _observersLock = new object();

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

        }
    }
}
