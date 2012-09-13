using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class RelatedContentItem : System.Web.UI.UserControl
    {
        public INode RelatedNode { get; set; }
        public String Description { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RelatedNode.GetProperty("teaser") != null && !String.IsNullOrEmpty(RelatedNode.GetProperty("teaser").Value))
            {
                Description = RelatedNode.GetProperty("teaser").Value;
            }
            else if (RelatedNode.GetProperty("metaDescription") != null && !String.IsNullOrEmpty(RelatedNode.GetProperty("metaDescription").Value))
            {
                Description = RelatedNode.GetProperty("metaDescription").Value;
            }

            if (!String.IsNullOrEmpty(Description) && Description.Length > 100)
            {
                int index = Description.IndexOf(" ", 100);
                Description = Description.Substring(0, index) + "...";
            }
        }
    }
}
