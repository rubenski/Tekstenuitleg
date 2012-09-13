using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.entitities;
using CursusIndex.util;
using umbraco;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class RelatedContent : System.Web.UI.UserControl
    {
        public string Header;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            Node current = Node.GetCurrent();
            IProperty relatedContent = current.GetProperty("relatedContent");

            if (relatedContent != null)
            {
                var relatedLinks = UmbracoFieldReader.ReadRelatedLinksField(relatedContent);
                if (relatedLinks.Count > 0)
                {
                    Header = library.GetDictionaryItem("RelatedContentMenuHeader");
                }
                RelatedNodesRepeater.DataSource = relatedLinks.Select(umbracoRelatedLink => new Node(umbracoRelatedLink.LinkedNode)).Cast<INode>().ToList();
                RelatedNodesRepeater.DataBind();
            }
        }
    }
}