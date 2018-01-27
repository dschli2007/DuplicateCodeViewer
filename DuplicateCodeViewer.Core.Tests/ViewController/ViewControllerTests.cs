using System.Collections.Generic;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.Tests.Fakes;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.ViewController
{
    [TestFixture]
    public class ViewControllerTests
    {

        [Test]
        public void SetContext_WhenCalled_ShouldSetInternalContext()
        {
            const string testFilename = "test.cs";
            const string lineContent = "Line 1";
            var factory = new FileReaderFactoryFake();
            factory.FileContents[testFilename] = new[] { lineContent };
            var sourceFile = new SourceFile(testFilename);

            var obtainedLineCount = 0;
            var obtainedLine = "";

            var obj = new Core.ViewController.ViewController(factory);
            obj.OnUpdateFileLines += (sender, list) =>
            {
                obtainedLineCount = list.Count;
                if (list.Count > 0)
                    obtainedLine = list[0].Content;
            };

            obj.SetContext(sourceFile, new Duplicate[0]);
            Assert.AreEqual(1, obtainedLineCount);
            Assert.AreEqual(lineContent, obtainedLine);
        }

        [Test]
        public void SetContext_WhenParametersNull_ShouldUpdateContext()
        {
            const string testFilename = "test.cs";
            const string lineContent = "Line 1";
            var factory = new FileReaderFactoryFake();
            factory.FileContents[testFilename] = new[] { lineContent };
            var sourceFile = new SourceFile(testFilename);

            var obtainedLineCount = 0;

            var obj = new Core.ViewController.ViewController(factory);
            obj.OnUpdateFileLines += (sender, list) =>
            {
                obtainedLineCount = list.Count;
            };

            obj.SetContext(sourceFile, new Duplicate[0]);
            Assert.AreEqual(1, obtainedLineCount);
            obj.SetContext(null, new Duplicate[0]);
            Assert.AreEqual(0, obtainedLineCount);
        }

        [Test]
        public void SetContext_WhenSingleFileHasDuplicates_ShouldNotSetDuplicateShowdInDuplicateFile()
        {
            const string testFilename = "test.cs";

            var factory = new FileReaderFactoryFake();
            factory.FileContents[testFilename] = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m" };

            var sourceFile = new SourceFile(testFilename);
            var duplicate = new Duplicate
            {
                Fragments = new[]
                {
                    new Fragment
                    {
                        SourceFile = sourceFile,
                        LineStart = 2,
                        LineEnd = 3
                    },
                    new Fragment
                    {
                        SourceFile = sourceFile,
                        LineStart = 5,
                        LineEnd = 6
                    },
                    new Fragment
                    {
                        SourceFile = sourceFile,
                        LineStart = 8,
                        LineEnd = 9
                    }
                }
            };

            IList<SourceFile> duplicatesObtained = new List<SourceFile>();
            IList<Line> duplicateLines = new List<Line>();

            var obj = new Core.ViewController.ViewController(factory);
            obj.OnUpdateDuplicateFiles += (sender, list) =>
            {
                duplicatesObtained = list;
            };
            obj.OnUpdateDuplicateFileLines += (sender, list) => { duplicateLines = list; };

            obj.SetContext(sourceFile, new[] { duplicate });
            obj.SetCurrentFileLine(1);
            Assert.AreEqual(0, duplicatesObtained.Count);
            Assert.AreEqual(0, duplicateLines.Count);

            obj.SetCurrentFileLine(2);
            obj.SetCurrentDuplicateFile(sourceFile);
            Assert.IsNull(duplicateLines[1].Duplicate);
            Assert.IsNull(duplicateLines[2].Duplicate);
            Assert.IsNotNull(duplicateLines[4].Duplicate);
            Assert.IsNotNull(duplicateLines[5].Duplicate);

            obj.SetCurrentFileLine(5);
            obj.SetCurrentDuplicateFile(sourceFile);
            Assert.IsNull(duplicateLines[4].Duplicate);
            Assert.IsNull(duplicateLines[5].Duplicate);
            Assert.IsNotNull(duplicateLines[1].Duplicate);
            Assert.IsNotNull(duplicateLines[2].Duplicate);

            obj.SetCurrentFileLine(1);
            obj.SetCurrentDuplicateFile(null);
            Assert.AreEqual(0, duplicateLines.Count);

        }

        [Test]
        public void SetCurrentFileLine_WhenValidLine_ShouldUpdateFile()
        {
            const string testFilename = "test.cs";
            const string testFilename2 = "test2.cs";

            var factory = new FileReaderFactoryFake();
            factory.FileContents[testFilename] = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            factory.FileContents[testFilename2] = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            var sourceFile = new SourceFile(testFilename);
            var sourceFile2 = new SourceFile(testFilename2);

            var duplicate = new Duplicate
            {
                Fragments = new[]
                {
                    new Fragment
                    {
                        SourceFile = sourceFile,
                        LineStart = 2,
                        LineEnd = 3
                    },
                    new Fragment
                    {
                        SourceFile = sourceFile2,
                        LineStart = 5,
                        LineEnd = 6
                    }
                }
            };

            IList<SourceFile> duplicatesObtained = new List<SourceFile>();

            var obj = new Core.ViewController.ViewController(factory);
            obj.OnUpdateDuplicateFiles += (sender, list) =>
            {
                duplicatesObtained = list;
            };
            obj.SetContext(sourceFile, new[] { duplicate });
            obj.SetCurrentFileLine(1);
            Assert.AreEqual(0, duplicatesObtained.Count);
            obj.SetCurrentFileLine(2);
            Assert.AreEqual(1, duplicatesObtained.Count);
            Assert.AreSame(sourceFile2, duplicatesObtained[0]);
            obj.SetCurrentFileLine(3);
            Assert.AreEqual(1, duplicatesObtained.Count);
            obj.SetCurrentFileLine(4);
            Assert.AreEqual(0, duplicatesObtained.Count);
        }

        [Test]
        public void SetCurrentFileLine_WhenNoFileInContext_ShouldDoNothing()
        {
            var factory = new FileReaderFactoryFake();

            var updateCount = 0;

            var obj = new Core.ViewController.ViewController(factory);
            obj.OnUpdateDuplicateFiles += (sender, list) => { updateCount++; };
            obj.SetCurrentFileLine(0);
            obj.SetCurrentFileLine(1);
            Assert.AreEqual(0, updateCount);
        }

        [Test]
        public void SetCurrentDuplicateFile_WhenCalled_ShouldReturnLinesFromDuplicatedFile()
        {
            const string testFilename = "test.cs";
            const string testFilename2 = "test2.cs";

            var factory = new FileReaderFactoryFake();
            factory.FileContents[testFilename] = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            factory.FileContents[testFilename2] = new[] { "a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2", "i2" };
            var sourceFile = new SourceFile(testFilename);
            var sourceFile2 = new SourceFile(testFilename2);

            var duplicate = new Duplicate
            {
                Fragments = new[]
                {
                    new Fragment
                    {
                        SourceFile = sourceFile,
                        LineStart = 2,
                        LineEnd = 3
                    },
                    new Fragment
                    {
                        SourceFile = sourceFile2,
                        LineStart = 3,
                        LineEnd = 4
                    }
                }
            };

            IList<Line> linesObtained = new List<Line>();

            var obj = new Core.ViewController.ViewController(factory);
            obj.OnUpdateDuplicateFileLines += (sender, list) =>
            {
                linesObtained = list;
            };
            obj.SetContext(sourceFile, new[] { duplicate });
            obj.SetCurrentFileLine(1);
            Assert.AreEqual(0, linesObtained.Count);
            obj.SetCurrentFileLine(2);
            obj.SetCurrentDuplicateFile(sourceFile2);
            Assert.AreEqual(9, linesObtained.Count);
            Assert.AreEqual("a2", linesObtained[0].Content);
            Assert.IsNull(linesObtained[0].Duplicate);
            Assert.IsNull(linesObtained[1].Duplicate);
            Assert.IsNotNull(linesObtained[2].Duplicate);
            Assert.IsNotNull(linesObtained[3].Duplicate);
            Assert.IsNull(linesObtained[4].Duplicate);
        }

    }
}
