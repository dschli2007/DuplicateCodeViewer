using System;
using System.IO;
using System.Xml;

namespace DuplicateCodeViewer.Core.Tests.Resources
{
    internal static class ResourceHelper
    {
        private const string ResourceName = "DuplicateCodeViewer.Core.Tests.Resources.complete.xml";

        public static XmlDocument CreateXmlDocument()
        {
            var result = new XmlDocument();
            var stream = typeof(ResourceHelper).Assembly.GetManifestResourceStream(ResourceName);
            try
            {
                result.Load(stream ?? throw new InvalidOperationException());
            }
            finally
            {
                stream?.Dispose();
            }
            return result;
        }

        public static string CreateXmlFile()
        {
            var filename = Path.GetTempFileName();

            var stream = typeof(ResourceHelper).Assembly.GetManifestResourceStream(ResourceName);
            try
            {
                using (var fs = new FileStream(filename, FileMode.Create))
                {
                    stream?.CopyTo(fs);
                }
            }
            finally
            {
                stream?.Dispose();
            }

            return filename;
        }

    }
}
