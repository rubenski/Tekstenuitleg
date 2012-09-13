using System;
using CursusIndex.business_logic.entitities;
using umbraco.NodeFactory;

namespace Tekstenuitleg.usercontrols
{
    public partial class ArticleMenuItem : System.Web.UI.UserControl
    {
        public ArticleListItem ListItem { get; set; }
        public Node CurrentNode { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}