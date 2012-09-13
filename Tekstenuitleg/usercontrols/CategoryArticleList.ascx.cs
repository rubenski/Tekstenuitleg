using System;
using System.Collections.Generic;
using System.Linq;
using CursusIndex.business_logic.business_objects;
using CursusIndex.business_logic.entitities;
using CursusIndex.util;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class CategoryArticleList : System.Web.UI.UserControl
    {
        private ICategoryBo _categoryBo = BusinessFactory.GetCategoryBo();
        public string ArticleListHeader;

        protected void Page_Load(object sender, EventArgs e)
        {
            INode currentPage = Node.GetCurrent();
            var articles = new List<INode>();

            if(currentPage.NodeTypeAlias.Equals("Category"))
            {
                articles = _categoryBo.FindAllCategoryArticles(currentPage);
            }
            else if (currentPage.NodeTypeAlias.Equals("Theme"))
            {
                articles = _categoryBo.FindThemedCategoryArticles(currentPage).ToList();
            }

            var articleListItems = articles.Select(article => new ArticleListItem(article)).ToList();
            ArticleListHeader = currentPage.Name;
            ArticleListRepeater.DataSource = articleListItems;
            ArticleListRepeater.DataBind();
        }        
    }
}