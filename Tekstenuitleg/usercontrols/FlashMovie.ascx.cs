using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tekstenuitleg.usercontrols
{
    public partial class FlashMovie : System.Web.UI.UserControl
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string FlashFile { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("TEST");

        }
    }
}