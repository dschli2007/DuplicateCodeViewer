using System.Xml;

namespace DuplicateCodeViewer.Core.XmlParser
{
    internal class DuplicateXmlNodeReader
    {
        internal struct FragmentInfo
        {
            public string Filename { get; set; }
            public int LineStart { get; set; }
            public int LineEnd { get; set; }
        }

        private const int DefaultCost = 1;
        private XmlNode _node;

        public int Cost { get; private set; }
        public FragmentInfo Fragment1 { get; private set; }
        public FragmentInfo Fragment2 { get; private set; }

        public void Read(XmlNode node)
        {
            _node = node;
            ReadCost();
            ReadFragments();
        }

        private void ReadCost()
        {
            var value = _node.Attributes?["Cost"]?.Value;
            Cost = !string.IsNullOrEmpty(value) ? int.Parse(value) : DefaultCost;
        }

        private void ReadFragments()
        {
            var child = _node.FirstChild;
            Fragment1 = ReadFragment(child);

            var child2 = child.NextSibling;
            Fragment2 = ReadFragment(child2);
        }

        private FragmentInfo ReadFragment(XmlNode node)
        {
            var result = new FragmentInfo();
            var propertyNode = node.FirstChild;
            while (propertyNode != null)
            {
                if (propertyNode.Name == "FileName")
                    result.Filename = propertyNode.InnerText;
                else if (propertyNode.Name == "LineRange")
                {
                    result.LineStart = TryGetIntegerAttribute(propertyNode, "Start", 1);
                    result.LineEnd = TryGetIntegerAttribute(propertyNode, "End", 1);
                }
                propertyNode = propertyNode.NextSibling;
            }
            return result;
        }

        private static int TryGetIntegerAttribute(XmlNode node, string attributeName, int defaultValue)
        {
            var value = node.Attributes?[attributeName]?.Value;
            return !string.IsNullOrEmpty(value) ? int.Parse(value) : defaultValue;
        }
    }
}