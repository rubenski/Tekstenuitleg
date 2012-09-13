using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.util;
using umbraco;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class BlogPostItem : System.Web.UI.UserControl
    {
        public INode BlogPost;
        public string Text;
        public string PostDate;
        public bool ShowReadMore;
        public int SnippetSize { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Text = BlogPost.GetProperty("body").Value;

            ShowReadMore = Text.Length > SnippetSize;
            if (ShowReadMore)
            {
                Text = Text.Substring(0, SnippetSize);
                Text = Text.Substring(0, Text.LastIndexOf(" ")) + "...  ";
                Text = MacroUtil.RenderInlineMacros(Text);
            }

            PostDate = DateUtil.GetLocalizedCreateDate(BlogPost);

        }
    }
}