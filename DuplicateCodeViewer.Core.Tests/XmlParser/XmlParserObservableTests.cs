using System.Xml;
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

        private XmlDocument GetXmlDocument()
        {
            const string sampleDocument = @"<Samples><Duplicate Cost=""210"">
      <Fragment>
        <FileName>..\file1.cs</FileName>
        <OffsetRange Start=""3027"" End=""3564""></OffsetRange>
        <LineRange Start=""72"" End=""82""></LineRange>
      </Fragment>
      <Fragment>
        <FileName>..\file2.cs</FileName>
        <OffsetRange Start=""3911"" End=""4448""></OffsetRange>
        <LineRange Start=""92"" End=""102""></LineRange>
      </Fragment>
    </Duplicate><Duplicate Cost=""211"">
      <Fragment>
        <FileName>..\file3.cs</FileName>
        <OffsetRange Start=""3027"" End=""3564""></OffsetRange>
        <LineRange Start=""73"" End=""83""></LineRange>
      </Fragment>
      <Fragment>
        <FileName>..\file4.cs</FileName>
        <OffsetRange Start=""3911"" End=""4448""></OffsetRange>
        <LineRange Start=""93"" End=""103""></LineRange>
      </Fragment>
    </Duplicate></Samples>";
            var result = new XmlDocument();
            result.LoadXml(sampleDocument);
            return result;
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

        [Test]
        public void Parse_WhenValidDocument_ShouldParseFilenames()
        {
            var observer = new XmlParserObserverFake();

            var parser = CreateParser();
            parser.AddObserver(observer);
            parser.Parse(GetXmlDocument());

            Assert.AreEqual(2, observer.Duplicates.Count);
            Assert.AreEqual(@"..\file1.cs", observer.Duplicates[0].Fragments[0].SourceFile.Filename);
            Assert.AreEqual(@"..\file2.cs", observer.Duplicates[0].Fragments[1].SourceFile.Filename);
            Assert.AreEqual(@"..\file3.cs", observer.Duplicates[1].Fragments[0].SourceFile.Filename);
            Assert.AreEqual(@"..\file4.cs", observer.Duplicates[1].Fragments[1].SourceFile.Filename);
        }

        [Test]
        public void Parse_WhenValidDocument_ShouldParseCosts()
        {
            var observer = new XmlParserObserverFake();

            var parser = CreateParser();
            parser.AddObserver(observer);
            parser.Parse(GetXmlDocument());

            Assert.AreEqual(2, observer.Duplicates.Count);
            Assert.AreEqual(210, observer.Duplicates[0].Cost);
            Assert.AreEqual(211, observer.Duplicates[1].Cost);
        }

        [Test]
        public void Parse_WhenValidDocument_ShouldParseLineStart()
        {
            var observer = new XmlParserObserverFake();

            var parser = CreateParser();
            parser.AddObserver(observer);
            parser.Parse(GetXmlDocument());

            Assert.AreEqual(2, observer.Duplicates.Count);
            Assert.AreEqual(72, observer.Duplicates[0].Fragments[0].LineStart);
            Assert.AreEqual(92, observer.Duplicates[0].Fragments[1].LineStart);
            Assert.AreEqual(73, observer.Duplicates[1].Fragments[0].LineStart);
            Assert.AreEqual(93, observer.Duplicates[1].Fragments[1].LineStart);
        }

        [Test]
        public void Parse_WhenValidDocument_ShouldParseLineEnd()
        {
            var observer = new XmlParserObserverFake();

            var parser = CreateParser();
            parser.AddObserver(observer);
            parser.Parse(GetXmlDocument());

            Assert.AreEqual(2, observer.Duplicates.Count);
            Assert.AreEqual(82, observer.Duplicates[0].Fragments[0].LineEnd);
            Assert.AreEqual(102, observer.Duplicates[0].Fragments[1].LineEnd);
            Assert.AreEqual(83, observer.Duplicates[1].Fragments[0].LineEnd);
            Assert.AreEqual(103, observer.Duplicates[1].Fragments[1].LineEnd);

        }

    }
}
