using System;
using System.Collections.Generic;
using CursusIndex.business_logic.business_objects;
using CursusIndex.util;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using System.Linq;
using umbraco.interfaces;


namespace Tekstenuitleg.usercontrols
{
    public partial class HeaderNavigation : System.Web.UI.UserControl
    {
        IGenericNodeBo nodeBo = BusinessFactory.GetGenericNodeBo();
        private ICategoryBo categoryBo = BusinessFactory.GetCategoryBo();
        public INode CurrentCategory;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            INode homepage = SiteUtil.FindCurrentHomepage();
            CurrentCategory = categoryBo.FindCurrentSection(Node.GetCurrent());
            IEnumerable<INode> navNodes = nodeBo.FindDescendants(homepage, new List<string>() { "Category", "BlogHome" });
            NavigationRepeater.DataSource = navNodes;
            NavigationRepeater.DataBind();
        }
    }
}