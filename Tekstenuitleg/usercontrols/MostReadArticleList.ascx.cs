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
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class MostReadArticleList : System.Web.UI.UserControl
    {
        private IGenericNodeBo nodeBo = BusinessFactory.GetGenericNodeBo();

        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<INode> articles = nodeBo.FindDescendants(SiteUtil.FindCurrentHomepage(), new List<string> {"Article"}, new List<int> {4});
            var homepageArticles = new List<INode>();

            foreach (var article in articles)
            {
                if(article.GetProperty("homepagePosition") != null)
                {
                    int pos = -10;
                    string homepagePositionString = article.GetProperty("homepagePosition").Value;
                    if(int.TryParse(homepagePositionString, out pos))
                    {
                        homepageArticles.Add(article);
                    }
                }
            }
            
            homepageArticles.Sort(new HomepageArticleSorter());
            List<ArticleListItem> articleListItems = homepageArticles.Select(homepageArticle => new ArticleListItem(homepageArticle)).ToList();
            HomepageArticles.DataSource = articleListItems;
            HomepageArticles.DataBind();
        }
    }
}