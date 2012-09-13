using System.Collections.Generic;
using System.Linq;
using CursusIndex.business_logic.business_objects;
using CursusIndex.data_logic;
using CursusIndex.util.ordering;
using umbraco.interfaces;

namespace Tekstenuitleg.business_logic.business_objects
{
    public class CategoryBo : ICategoryBo
    {
        private readonly IGenericNodeDao nodeDao = DaoFactory.GetUmbracoDaoFactory().GetGenericNodeDao();

        public List<INode> FindThemedCategoryArticles(INode theme, NodeOrder order, int startAt = 0)
        {
            IEnumerable<INode> articles = FindAllCategoryArticles(FindCurrentSection(theme), order);
            var themeArticles = new List<INode>();
            foreach (var article in articles)
            {
                IProperty themeProperty = article.GetProperty("applicableThemes");
                if (themeProperty != null)
                {
                    string themes = themeProperty.Value;
                    if (themes.Contains(theme.Id.ToString()))
                    {
                        themeArticles.Add(article);
                    }
                }
            }

            return themeArticles;
        }

        public List<INode> FindAllCategoryArticles(INode category, NodeOrder order, int startAt = 0)
        {
            IEnumerable<INode> nodes = nodeDao.FindDescendants(category, new List<string> { "Article" }, new List<int> { 4 });
            return OrderingUtil.OrderByCreateDate(nodes, order == NodeOrder.DateAndTimeAscending ? Order.Ascending : Order.Descending);
        }


        public INode FindCurrentSection(INode currentPage)
        {
            if (currentPage.NodeTypeAlias.Equals("Category") || currentPage.NodeTypeAlias.Equals("BlogHome"))
            {
                return currentPage;
            }

            if (currentPage.NodeTypeAlias.Equals("Article") || currentPage.NodeTypeAlias.Equals("ArticleSubPage") || currentPage.NodeTypeAlias.Equals("Theme"))
            {
                return nodeDao.FindAncestors(currentPage, new List<string> { "Category" }, new List<int> { 3 }).FirstOrDefault();
            }

            if (currentPage.NodeTypeAlias.Equals("BlogPost"))
            {
                return nodeDao.FindAncestors(currentPage, new List<string> { "BlogHome" }, new List<int> { 2 }).FirstOrDefault();
            }

            return null;
        }
    }
}