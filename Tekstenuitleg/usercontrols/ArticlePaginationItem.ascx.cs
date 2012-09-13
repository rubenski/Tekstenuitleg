using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.entitities;

namespace Tekstenuitleg.usercontrols
{
    public partial class ArticlePaginationItem : System.Web.UI.UserControl
    {
        public ArticleListItem ListItem;
        public int PageNumber;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}