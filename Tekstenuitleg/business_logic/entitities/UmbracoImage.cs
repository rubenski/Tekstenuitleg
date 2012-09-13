using System;
using System.Xml;

namespace CursusIndex.business_logic.entitities
{
    public class UmbracoImage
    {
        public string Src { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public int Id { get; set; }

        public UmbracoImage(XmlNode imageXml)
        {
            if (imageXml == null)
            {
                throw new ArgumentException("Cannot create image from null xml");
            }
            Src = imageXml.SelectSingleNode("//Image/umbracoFile").InnerText;
            Width = imageXml.SelectSingleNode("//Image/umbracoWidth").InnerText;
            Height = imageXml.SelectSingleNode("//Image/umbracoHeight").InnerText;

            string mediaId = imageXml.SelectSingleNode("//Image").Attributes.GetNamedItem("id").Value;

            int id = -10;
            int.TryParse(mediaId, out id);
            Id = id;
        }

        public UmbracoImage()
        {
            Src = "";
            Width = "";
            Height = "";
        }

        public string GetImageScalerUrlWorksWithLicenseOnly(string className)
        {
            // string mediaUrl = Src.Replace("/media", "");
            string url = "/ImageGen.ashx?image=" + Src + "&class=" + className;
            return url;
        }

        public string GetImageUrl(int width, int height, bool constrainProportions, string backgroundColor, string crop, bool pad)
        {
            string url = "/ImageGen.ashx?image=" + Src +
                         "&amp;width=" + width +
                         "&amp;height=" + height +
                         "&amp;constrain=" + constrainProportions +
                         "&amp;bgcolor=" + backgroundColor +
                         "&amp;crop=" + crop +
                         "&amp;pad=" + pad;

            return url;
        }
    }
}

