using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.business_objects;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;
using CursusIndex.util;

namespace Tekstenuitleg.usercontrols
{
    public partial class BlogList : System.Web.UI.UserControl
    {
        private IBlogBo blogBo = BusinessFactory.GetBlogBo();


        public int SnippetSize { get; set; }
        public int NumberOfPosts { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<INode> blogPosts = blogBo.FindLatestBlogPosts();

            if(NumberOfPosts > 0 && blogPosts.Count > NumberOfPosts){
                blogPosts = blogPosts.GetRange(0, NumberOfPosts);
            }

            BlogRepeater.DataSource = blogPosts;
            BlogRepeater.DataBind();
        }
    }
}