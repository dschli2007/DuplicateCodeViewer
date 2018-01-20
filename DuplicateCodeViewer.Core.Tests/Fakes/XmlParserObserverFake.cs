using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.XmlParser;

namespace DuplicateCodeViewer.Core.Tests.Fakes
{
    internal class XmlParserObserverFake : IXmlParserObserver
    {
        public List<Duplicate> Duplicates { get; } = new List<Duplicate>();

        public void DuplicateParsed(Duplicate duplicate)
        {
            Duplicates.Add(duplicate);
        }
    }
}