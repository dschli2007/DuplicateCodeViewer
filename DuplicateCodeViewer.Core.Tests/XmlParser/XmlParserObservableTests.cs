using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.XmlParser;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.XmlParser
{
    [TestFixture]
    public class XmlParserObservableTests
    {
        private static XmlParserObservable CreateParser()
        {
            return new XmlParserObservable();
        }

        [Test]
        public void AddObserver_WhenValidObserver_ShouldAddObserverToObserverList()
        {
            var sampleDuplicate = new Duplicate { Cost = 123 };
            var sampleObserver = new XmlParserObserverTest();

            var parser = CreateParser();
            parser.AddObserver(sampleObserver);
            parser.Notify(sampleDuplicate);

            Assert.AreEqual(1, sampleObserver.Duplicates.Count);
            Assert.AreSame(sampleDuplicate, sampleObserver.Duplicates[0]);
        }

        [Test]
        public void RemoveObserver_WhenObserverInTheList_ShouldRemoveObserverToObserverList()
        {
            var sampleDuplicate = new Duplicate { Cost = 123 };
            var sampleObserver = new XmlParserObserverTest();

            var parser = CreateParser();
            parser.AddObserver(sampleObserver);
            parser.Notify(sampleDuplicate);

            parser.RemoveObserver(sampleObserver);
            parser.Notify(sampleDuplicate);
            
            Assert.AreEqual(1, sampleObserver.Duplicates.Count);
        }

    }

    internal class XmlParserObserverTest : IXmlParserObserver
    {
        public List<Duplicate> Duplicates { get; } = new List<Duplicate>();

        public void DuplicateParsed(Duplicate duplicate)
        {
            Duplicates.Add(duplicate);
        }
    }
}
