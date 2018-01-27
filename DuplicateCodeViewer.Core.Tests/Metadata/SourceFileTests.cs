using DuplicateCodeViewer.Core.Metadata;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.Metadata
{
    [TestFixture]
   public class SourceFileTests
    {
        [TestCase("")]
        [TestCase("file.txt")]
        [TestCase(@"c:\dir\file.txt")]
        public void ToString_WhenHasFilename_ShouldReturnFilename(string filename)
        {
            var obj = new SourceFile(filename);
            Assert.AreEqual(filename, obj.ToString());
        }

    }
}
