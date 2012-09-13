using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class HeaderNavItem : System.Web.UI.UserControl
    {
        public INode Category;
        public INode CurrentCategory;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}