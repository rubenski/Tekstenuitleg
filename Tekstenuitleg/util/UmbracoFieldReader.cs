using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;
using CursusIndex.business_logic.entitities;
using umbraco.NodeFactory;
using umbraco.interfaces;


namespace CursusIndex.util
{
    public static class UmbracoFieldReader
    {
        public static string ReadSimpleEditorField(umbraco.cms.businesslogic.property.Property nodeProperty)
        {
            return ReadStringField(nodeProperty).Replace("\r\n", "<br>");
        }

        public static int ReadIntegerField(Property property, int defaultValue)
        {
            if (property == null)
            {
                throw new ArgumentException("property cannot be null when trying to read integer field");
            }

            string stringValue = property.Value;

            int value = -10;
            if (int.TryParse(stringValue, out value))
            {
                return value;
            }

            return defaultValue;
        }

        public static DateTime ReadDateTimeField(Property nodeProperty)
        {
            DateTime value = DateTime.MinValue;
            DateTime newValue;
            if (nodeProperty != null)
            {
                DateTime.TryParse(nodeProperty.Value.ToString(), out newValue);
                value = newValue;
            }
            return value;
        }

        public static Boolean ReadBooleanField(umbraco.cms.businesslogic.property.Property nodeProperty)
        {
            Boolean value = false;
            if (nodeProperty != null)
            {
                value = (nodeProperty.Value.ToString() == "1");
            }
            return value;
        }

        public static Boolean ReadBooleanField(Property property)
        {

            if (property != null)
            {
                string val = property.Value;
                if (val.Equals("0"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public static string ReadStringField(IProperty property, string alternative = "")
        {
            string value = string.Empty;
            if (property != null && !string.IsNullOrEmpty(property.Value))
            {
                value = property.Value;
            }
            else
            {
                value = alternative;
            }
            return value;
        }

        public static string ReadStringField(umbraco.cms.businesslogic.property.Property nodeProperty)
        {
            string value = string.Empty;
            if (nodeProperty != null)
            {
                value = nodeProperty.Value.ToString();
            }
            return value;
        }

        public static Node ReadContentPickerField(Property contentPickerProperty)
        {
            string idString = contentPickerProperty.Value;
            int id = -10;
            int.TryParse(idString, out id);
            return new Node(id);
        }


        public static UmbracoFile ReadMediaPickerFileField(Property fileProperty)
        {
            UmbracoFile file = null;

            if (fileProperty == null)
            {
                return null;
            }

            XmlNode fileAsXml = GetSingleMediaItem(fileProperty);


            if (fileAsXml != null && !string.IsNullOrEmpty(fileAsXml.OuterXml))
            {
                // Check if it is absolutely safe to create the image
                XmlNode fileNode = fileAsXml.SelectSingleNode("//File/umbracoFile");
                XmlNode byteNode = fileAsXml.SelectSingleNode("//File/umbracoBytes");

                if (fileNode != null && byteNode != null)
                {
                    file = new UmbracoFile(fileAsXml);
                }

            }
            return file;
        }

        public static UmbracoImage ReadMediaPickerImageField(IProperty imageProperty)
        {
            if (imageProperty == null)
            {
                return null;
            }

            return XmlNodeToImage(GetSingleMediaItem(imageProperty));
        }

        private static UmbracoImage XmlNodeToImage(XmlNode imageNode)
        {
            UmbracoImage image = null;

            if (imageNode != null && !string.IsNullOrEmpty(imageNode.OuterXml))
            {
                // Check if it is absolutely safe to create the image
                if (imageNode.SelectSingleNode("//Image/umbracoFile") != null
                    && imageNode.SelectSingleNode("//Image/umbracoWidth") != null
                    && imageNode.SelectSingleNode("//Image/umbracoHeight") != null)
                {
                    image = new UmbracoImage(imageNode);
                }
            }
            return image;
        }

        public static UmbracoImage ReadMediaImageFromIterator(XPathNodeIterator iterator)
        {
            XmlNode imageNode = GetXmlNodeFromMedia(iterator);
            return XmlNodeToImage(imageNode);
        }

        private static XmlNode GetSingleMediaItem(IProperty imageProperty)
        {
            if (imageProperty == null)
            {
                throw new ArgumentException("Null imageProperty is not allowed");
            }

            if (imageProperty.Value != null && imageProperty.Value.ToString() != "")
            {
                int imageId = -10;
                int.TryParse(imageProperty.Value, out imageId);

                XPathNodeIterator mediaIterator = umbraco.library.GetMedia(imageId, true);
                return GetXmlNodeFromMedia(mediaIterator);
            }
            return null;
        }

        private static XmlNode GetXmlNodeFromMedia(XPathNodeIterator iterator)
        {
            if (iterator != null && iterator.Count > 0)
            {
                string mediaXml = iterator.Current.InnerXml;
                XmlDocument xmlMediaDocument = new XmlDocument();
                xmlMediaDocument.LoadXml(mediaXml);
                return xmlMediaDocument; 
            }

            return null;
        }


        public static List<UmbracoRelatedLink> ReadRelatedLinksField(IProperty property)
        {
            var relatedLinks = new List<UmbracoRelatedLink>();

            if (property == null)
            {
                return relatedLinks;
            }

            // If the value passed into this method is an integer, than there are no related links.
            int value;
            if (int.TryParse(property.Value, out value))
            {
                return relatedLinks;
            }
            // Get link nodes as XML
            IList<XmlNode> xmlLinks = GetChildNodes(property.Value);
            // Convert the links to UmbracoRelatedLink entities and return
            return xmlLinks.Select(link => new UmbracoRelatedLink(link)).ToList();
        }

        public static List<Node> ReadThemaField(Property property)
        {
            if (property == null)
            {
                throw new ArgumentException("Null argument is invalid");
            }

            List<Node> nodes = new List<Node>();

            foreach (string nodeId in Regex.Split(property.Value, ","))
            {
                int id = -10;
                int.TryParse(nodeId, out id);
                nodes.Add(new Node(id));
            }

            return nodes;

        }

        public static IList<XmlNode> GetChildNodes(string xmlString)
        {
            if (xmlString == null)
            {
                throw new ArgumentException("Null arguments are not allowed");
            }

            XmlDocument links = new XmlDocument();
            links.LoadXml(xmlString);
            IList<XmlNode> nodeList = new List<XmlNode>();
            foreach (XmlNode node in links.DocumentElement.ChildNodes)
            {
                nodeList.Add(node);
            }

            return nodeList;
        }

    }

}
