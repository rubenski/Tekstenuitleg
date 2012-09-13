using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.interfaces;
using umbraco.NodeFactory;
using CursusIndex.business_logic.business_objects;
using CursusIndex.business_logic.entitities;

namespace Tekstenuitleg.usercontrols
{
    public partial class ArticlePagination : System.Web.UI.UserControl
    {
        public bool ShowPagination;
        readonly IArticleBo _articleBo = BusinessFactory.GetArticleBo();

        protected void Page_Load(object sender, EventArgs e)
        {
            var pages = _articleBo.FindFullArticle(Node.GetCurrent());
            ShowPagination = pages.Count > 1;
            ArticlePaginationRepeater.DataSource = pages;
            ArticlePaginationRepeater.DataBind();
        }
    }
}