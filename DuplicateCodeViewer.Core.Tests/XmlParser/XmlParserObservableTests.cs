using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.Tests.Fakes;
using DuplicateCodeViewer.Core.XmlParser;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.XmlParser
{
    [TestFixture]
    public class XmlParserObservableTests
    {
        private static XmlParserObservable CreateParser()
        {
            var sourceFileBuilder = new SourceFileBuilderFlyWeightFake();
            return new XmlParserObservable(sourceFileBuilder);
        }

        [Test]
        public void AddObserver_WhenValidObserver_ShouldAddObserverToObserverList()
        {
            var sampleDuplicate = new Duplicate { Cost = 123 };
            var sampleObserver = new XmlParserObserverFake();

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
            var sampleObserver = new XmlParserObserverFake();

            var parser = CreateParser();
            parser.AddObserver(sampleObserver);
            parser.Notify(sampleDuplicate);

            parser.RemoveObserver(sampleObserver);
            parser.Notify(sampleDuplicate);
            
            Assert.AreEqual(1, sampleObserver.Duplicates.Count);
        }

        [Test]
        public void Notify_WhenObserverInTheList_ShouldNotifyAllObservers()
        {
            var sampleDuplicate = new Duplicate { Cost = 123 };
            var sampleObserver1 = new XmlParserObserverFake();
            var sampleObserver2 = new XmlParserObserverFake();

            var parser = CreateParser();
            parser.AddObserver(sampleObserver1);
            parser.AddObserver(sampleObserver2);
            parser.Notify(sampleDuplicate);
            
            Assert.AreEqual(1, sampleObserver1.Duplicates.Count);
            Assert.AreEqual(1, sampleObserver2.Duplicates.Count);
        }

    }
}
