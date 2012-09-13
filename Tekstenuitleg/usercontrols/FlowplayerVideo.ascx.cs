using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tekstenuitleg.usercontrols
{
    public partial class FlowplayerVideo : System.Web.UI.UserControl
    {
        public string VideoFileName { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("video filename: " + VideoFileName);
        }

        public FlowplayerVideo()
        {
            // whataver
        }
    }
} 