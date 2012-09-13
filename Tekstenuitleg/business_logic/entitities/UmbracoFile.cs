using System;
using System.Xml;

namespace CursusIndex.business_logic.entitities
{
    public class UmbracoFile
    {
        public string FileUrl { get; set; }
        public int Bytes { get; set; }
        public int MediaId { get; set; }

        public UmbracoFile(XmlNode fileXml)
        {
            if (fileXml == null)
            {
                throw new ArgumentException("Cannot create file from null xml");
            }
            FileUrl = fileXml.SelectSingleNode("//File/umbracoFile").InnerText;

            int bytes = -10;
            int.TryParse(fileXml.SelectSingleNode("//File/umbracoBytes").InnerText, out bytes);
            Bytes = bytes;


            string mediaIdString = fileXml.SelectSingleNode("//File").Attributes.GetNamedItem("id").Value;

            int mediaId = -10;
            int.TryParse(mediaIdString, out mediaId);
            MediaId = mediaId;
        }
    }
}