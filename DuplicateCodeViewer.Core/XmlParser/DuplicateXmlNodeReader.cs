using System.Collections.Generic;
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
        private List<FragmentInfo> _fragments;

        public int Cost { get; private set; }

        public IEnumerable<FragmentInfo> Fragments
        {
            get
            {
                foreach (var fragment in _fragments)
                {
                    yield return fragment;
                }
            }
        }

        public void Read(XmlNode node)
        {
            _node = node;
            _fragments = new List<FragmentInfo>();
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
            var fragmentNode = _node.FirstChild;
            while (fragmentNode != null)
            {
                _fragments.Add(ReadFragment(fragmentNode));
                fragmentNode = fragmentNode.NextSibling;
            }
        }

        private static FragmentInfo ReadFragment(XmlNode node)
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