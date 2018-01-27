using System.Linq;
using System.Threading;
using DuplicateCodeViewer.Core.LoadController;
using DuplicateCodeViewer.Core.Tests.Fakes;
using DuplicateCodeViewer.Core.Tests.Resources;
using NUnit.Framework;

namespace DuplicateCodeViewer.Core.Tests.LoadController
{
    [TestFixture]
    public class InternalXmlParserObserverTests
    {
        [Test]
        public void Async_WhenTrue_ShouldLoadAsynchronous()
        {
            var lockObject = new object();
            var completed = false;
            var document = ResourceHelper.CreateXmlDocument();
            var obj = new InternalXmlParserObserver(new SourceFileBuilderFlyWeightFake(), document, observer =>
            {
                lock (lockObject)
                {
                    completed = true;
                }
            });

            obj.Async = true;
            obj.Execute();


            while (true)
            {
                lock (lockObject)
                {
                    if (completed)
                        break;
                    Thread.Sleep(0);
                }
            }
            Assert.IsTrue(completed);
        }

        [Test]
        public void Async_WhenFalse_ShouldLoadSynchronous()
        {
            var completed = false;
            var document = ResourceHelper.CreateXmlDocument();
            var obj = new InternalXmlParserObserver(new SourceFileBuilderFlyWeightFake(), document, observer =>
            {
                completed = true;
            });

            obj.Async = false;
            obj.Execute();

            Assert.IsTrue(completed);
        }


       [Test]
       public void Duplicates_AfterExecuted_ShouldReturnDuplicates()
       {
           var document = ResourceHelper.CreateXmlDocument();
           var obj = new InternalXmlParserObserver(new SourceFileBuilderFlyWeightFake(), document, observer => { })
               {
                   Async = false
               };

           obj.Execute();

           Assert.AreEqual(3, obj.Duplicates.Count());
       }

        [Test]
        public void UniqueSourceFiles_AfterExecuted_ShouldReturnUniqueFileList()
        {
            var document = ResourceHelper.CreateXmlDocument();
            var obj = new InternalXmlParserObserver(new SourceFileBuilderFlyWeightFake(), document, observer => { })
            {
                Async = false
            };

            obj.Execute();

            Assert.AreEqual(6, obj.UniqueSourceFiles.Count());
        }
        
    }
}
