using System;
using System.Collections.Generic;
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

        public static TempFile CreateXmlFile()
        {
            var result = new TempFile();

            var stream = typeof(ResourceHelper).Assembly.GetManifestResourceStream(ResourceName);
            try
            {
                result.WriteStreamToFile(stream);
            }
            finally
            {
                stream?.Dispose();
            }

            return result;
        }

        public static TempFile CreateSourceFile(int lines, string pattern)
        {
            var list = new List<string>(lines);
            while (list.Count < lines)
                list.Add(string.Format(pattern, list.Count + 1));
            
            var result = new TempFile();
            result.WriteStringsToFile(list);
            
            return result;
        }

    }
}
