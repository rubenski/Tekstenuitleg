using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.masterpages
{
    public partial class Homepage : System.Web.UI.MasterPage
    {
        public INode HomepageNode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            HomepageNode = Node.GetCurrent();


        }
    }
}