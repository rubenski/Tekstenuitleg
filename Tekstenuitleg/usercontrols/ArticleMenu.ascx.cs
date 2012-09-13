using System;
using System.Collections.Generic;
using System.Linq;
using CursusIndex.business_logic.business_objects;
using CursusIndex.business_logic.entitities;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class ArticleMenu : System.Web.UI.UserControl
    {

        private readonly IArticleBo articleBo = BusinessFactory.GetArticleBo();
        public Node CurrentNode;

        protected void Page_Load(object sender, EventArgs e)
        {
  
            CurrentNode = Node.GetCurrent();

            List<ArticleListItem> articlePages = articleBo.FindFullArticle(CurrentNode);
            ArticleMenuRepeater.DataSource = articlePages;
            ArticleMenuRepeater.DataBind();
        }
    }
}