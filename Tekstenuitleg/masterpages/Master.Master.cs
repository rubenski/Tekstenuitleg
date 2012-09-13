using System;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;

namespace Tekstenuitleg.masterpages
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public bool IncludeFlowplayerJavascript;
        public String IncludeSyntaxHighlightingForLanguages = "";
        public bool IncludeSyntaxHighlightingBaseFiles;
        private ISecurityBo securityBo = BusinessFactory.GetSecurityBo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (securityBo.GetBlockedIps().Contains(Request.UserHostAddress))
            {
                Request.RequestContext.HttpContext.Items.Add("showAdsense", "0");
            }else
            {
                Request.RequestContext.HttpContext.Items.Add("showAdsense", "1");
            }

            IncludeFlowplayerJavascript = Node.GetCurrent().GetProperty("includeFlowplayerJavascript") != null &&
                                          Node.GetCurrent().GetProperty("includeFlowplayerJavascript").Value.Equals("1");


            if (Node.GetCurrent().GetProperty("includeSyntaxHighlighterCode") != null && !String.IsNullOrEmpty(Node.GetCurrent().GetProperty("includeSyntaxHighlighterCode").Value))
            {
                IncludeSyntaxHighlightingForLanguages = Node.GetCurrent().GetProperty("includeSyntaxHighlighterCode").Value;
                IncludeSyntaxHighlightingBaseFiles = true;
            }                           


        }
    }
}