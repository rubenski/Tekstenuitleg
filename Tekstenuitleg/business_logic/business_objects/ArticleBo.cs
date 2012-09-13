using System.Collections.Generic;
using System.Linq;
using CursusIndex.business_logic.business_objects;
using umbraco.interfaces;
using CursusIndex.data_logic;
using CursusIndex.business_logic.entitities;
using CursusIndex.util.ordering;

namespace Tekstenuitleg.business_logic.business_objects
{
    public class ArticleBo : IArticleBo
    {
        IGenericNodeDao nodeDao = DaoFactory.GetUmbracoDaoFactory().GetGenericNodeDao();

        public List<ArticleListItem> FindFullArticle(INode articlePage)
        {
            INode articleRootPage = null;

            if (articlePage.NodeTypeAlias.Equals("Article"))
            {
                articleRootPage = articlePage;
            }
            else
            {
                articleRootPage = nodeDao.FindAncestors(articlePage, new List<string>() { "Article" }).ToList().Last();
            }

            var pageNodes = new List<ArticleListItem>();
            pageNodes.Add(new ArticleListItem(articleRootPage));
            foreach (var page in OrderingUtil.OrderByNumericProperty(articleRootPage.ChildrenAsList, "positionInArticle", Order.Ascending))
            {
                pageNodes.Add(new ArticleListItem(page));
            }

            return pageNodes;
        }
    }
}