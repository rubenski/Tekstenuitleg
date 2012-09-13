using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class BlogComment : System.Web.UI.UserControl
    {
        public INode Comment;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}