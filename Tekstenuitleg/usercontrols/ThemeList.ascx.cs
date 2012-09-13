using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.business_objects;
using CursusIndex.business_logic.entitities;
using CursusIndex.util;
using CursusIndex.util.ordering;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class ThemeList : System.Web.UI.UserControl
    {
        private readonly IThemeBo _themeBo = BusinessFactory.GetThemeBo();
        private readonly IGenericNodeBo _nodeBo = BusinessFactory.GetGenericNodeBo();
        private readonly ICategoryBo _categoryBo = BusinessFactory.GetCategoryBo();
        public bool AllSelected;
        public INode CurrentlySelected;
        public INode Category;

        protected void Page_Load(object sender, EventArgs e)
        {
            Category = _categoryBo.FindCurrentSection(Node.GetCurrent());
            IEnumerable<INode> themes = _nodeBo.FindDescendants(Category, new List<string> { "Theme" }, new List<int> { 5 });
            List<INode> orderedThemes = OrderingUtil.OrderByNumericProperty(themes, "position", Order.Ascending);
            var currentlySelectedTheme = _themeBo.FindCurrentlySelectedTheme(Request, Category);
            AllSelected = currentlySelectedTheme == null;
            var orderedThemeListItems = orderedThemes.Select(orderedTheme => new ThemeListItem(Category, orderedTheme, currentlySelectedTheme)).ToList();
            ThemeRepeater.DataSource = orderedThemeListItems;
            ThemeRepeater.DataBind();
        }
    }
}