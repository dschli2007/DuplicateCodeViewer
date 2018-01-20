using System.Linq;
using System.Xml;
using DuplicateCodeViewer.Core.XmlParser;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.XmlParser
{
    [TestFixture]
    public class DuplicateXmlNodeReaderTests
    {

        private static string DefaultXml = @"<Duplicate Cost=""210"">
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
    </Duplicate>";

        private XmlDocument _document;
        private XmlNode _duplicateNode;


        private DuplicateXmlNodeReader CreateReader()
        {
            return new DuplicateXmlNodeReader();
        }

        [SetUp]
        public void Initialize()
        {
            _document = new XmlDocument();
            _document.LoadXml(DefaultXml);
            _duplicateNode = _document.GetElementsByTagName("Duplicate")[0];
        }

        [Test]
        public void Read_WhenHasCostValue_ShouldReadCost()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);

            Assert.AreEqual(210, reader.Cost);
        }

        [Test]
        public void Read_WhenHasNoCostValue_ShouldReadDefaultCost()
        {
            _duplicateNode?.Attributes?.RemoveAll();

            var reader = CreateReader();
            reader.Read(_duplicateNode);

            Assert.AreEqual(1, reader.Cost);
        }

        [Test]
        public void Read_WhenValidNode_ShouldReadFragmentFileName1()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);
            Assert.AreEqual(@"..\file1.cs", reader.Fragments.First().Filename);
        }

        [Test]
        public void Read_WhenValidNode_ShouldReadFragmentLineStart1()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);
            Assert.AreEqual(72, reader.Fragments.First().LineStart);
        }

        [Test]
        public void Read_WhenValidNode_ShouldReadFragmentLineEnd1()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);
            Assert.AreEqual(82, reader.Fragments.First().LineEnd);
        }

        [Test]
        public void Read_WhenValidNode_ShouldReadFragmentFileName2()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);
            Assert.AreEqual(@"..\file2.cs", reader.Fragments.ToArray()[1].Filename);
        }

        [Test]
        public void Read_WhenValidNode_ShouldReadFragmentLineStart2()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);
            Assert.AreEqual(92, reader.Fragments.ToArray()[1].LineStart);
        }

        [Test]
        public void Read_WhenValidNode_ShouldReadFragmentLineEnd2()
        {
            var reader = CreateReader();
            reader.Read(_duplicateNode);
            Assert.AreEqual(102, reader.Fragments.ToArray()[1].LineEnd);
        }
    }
}