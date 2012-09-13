using System.Xml;

namespace CursusIndex.business_logic.entitities
{
    public class UmbracoRelatedLink
    {
        public UmbracoRelatedLink(XmlNode link)
        {

            Url = link.Attributes.GetNamedItem("link").InnerText;
            Titel = link.Attributes.GetNamedItem("title").InnerText;
            Type = link.Attributes.GetNamedItem("type").InnerText;
            NewWindow = link.Attributes.GetNamedItem("newwindow").InnerText == "0" ? 0 : 1;

            // If this is an internal link, convert the id to an internal URL
            if (Type.Equals("internal"))
            {
                int id = 0;
                int.TryParse(Url, out id);
                Url = umbraco.library.NiceUrl(id);
                LinkedNode = id;
            }

            Target = "_self";
            if (NewWindow == 1)
            {
                Target = "_blank";
            }
        }

        public UmbracoRelatedLink()
        {
        }

        public string Titel { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int NewWindow { get; set; }
        public string Target { get; set; }
        public string Class { get; set; }
        public int LinkedNode { get; set; }
    }
}