using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.business_objects;
using CursusIndex.util;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class BodyText : System.Web.UI.UserControl
    {
        
        public string Body;
        protected void Page_Load(object sender, EventArgs e)
        {
            INode node = Node.GetCurrent();
            Body = node.GetProperty("body").Value;
            if (Request.RequestContext.HttpContext.Items["showAdsense"].Equals("1"))
            {
                Body = AdsenseUtil.InsertAdsense(Body, "</p>");
            }
                
            Body = MacroUtil.RenderInlineMacros(Body);
        }
    }
}