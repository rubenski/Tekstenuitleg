using System;
using CursusIndex.business_logic.business_objects;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.masterpages
{
    public partial class Category : System.Web.UI.MasterPage
    {
        public INode CurrentCategory;

        
        private static readonly ICategoryBo CategoryBo = BusinessFactory.GetCategoryBo();

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentCategory = CategoryBo.FindCurrentSection(Node.GetCurrent());
            
        }
    }
}