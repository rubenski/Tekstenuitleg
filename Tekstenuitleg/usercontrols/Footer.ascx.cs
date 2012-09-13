using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.business_objects;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.interfaces;
using CursusIndex.util;
using CursusIndex.business_logic.entitities;

namespace Tekstenuitleg.usercontrols
{
    public partial class Footer : System.Web.UI.UserControl
    {
        private IGenericNodeBo nodeBo = BusinessFactory.GetGenericNodeBo();
        public string CopyrightMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the current homepage
            INode homepage = SiteUtil.FindCurrentHomepage();
            INode footer = nodeBo.FindDescendants(homepage, new List<string> { "Footer" }).FirstOrDefault();
            if (footer != null)
            {
                CopyrightMessage = footer.GetProperty("copyrightMessage").Value;
                LinkRepeater.DataSource = UmbracoFieldReader.ReadRelatedLinksField(footer.GetProperty("links"));
                LinkRepeater.DataBind();
            } 
        }
    }
}