using System;
using System.Collections.Generic;
using System.IO;

namespace DuplicateCodeViewer.Core.Tests.Resources
{
    internal class TempFile : IDisposable
    {
        public string Filename { get; private set; }

        public TempFile()
        {
            Filename = Path.GetTempFileName();
        }

        public void WriteStreamToFile(Stream stream)
        {
            using (var fs = new FileStream(Filename, FileMode.Create))
            {
                stream?.CopyTo(fs);
            }
        }

        public void WriteStringsToFile(IEnumerable<string> lines)
        {
            using (var sr = new StreamWriter(Filename))
            {
                foreach (var line in lines)
                {
                    sr.WriteLine(line);
                }
                sr.Flush();
            }
        }

        public void Dispose()
        {
            if (File.Exists(Filename))
                File.Delete(Filename);
        }

        ~TempFile()
        {
            Dispose();
        }


    }
}
