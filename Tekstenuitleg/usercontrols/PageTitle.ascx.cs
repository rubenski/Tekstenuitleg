using System;
using System.Diagnostics;
using CursusIndex.business_logic.business_objects;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class PageTitle : System.Web.UI.UserControl
    {
        private ICategoryBo categoryBo = BusinessFactory.GetCategoryBo();

        protected void Page_Load(object sender, EventArgs e)
        {

            INode currentPage = Node.GetCurrent();
            string nodeTypeAlias = currentPage.NodeTypeAlias;

            if (nodeTypeAlias.Equals("Category"))
            {
                if (currentPage.GetProperty("pageTitle") != null)
                {
                    title.Text = string.Format("{0} - Tekstenuitleg.net", currentPage.Name);
                }
            }
            else if (nodeTypeAlias.Equals("Theme"))
            {
                if (currentPage.GetProperty("pageTitle") != null &&  !String.IsNullOrEmpty(currentPage.GetProperty("pageTitle").Value.Trim()))
                {
                    title.Text = currentPage.GetProperty("pageTitle").Value;
                }
                else
                {
                    title.Text = string.Format("{0} : {1} - Tekstenuitleg.net", currentPage.Name, categoryBo.FindCurrentSection(Node.GetCurrent()).Name);
                }
            }
            else if (nodeTypeAlias.Equals("Article"))
            {
                if (currentPage.GetProperty("articleTitle") != null && !String.IsNullOrEmpty(currentPage.GetProperty("articleTitle").Value.Trim()))
                {
                    title.Text = currentPage.GetProperty("articleTitle").Value;
                }
                else
                {
                    title.Text = currentPage.Name;
                }

            }
            else if (nodeTypeAlias.Equals("ArticleSubPage"))
            {
                title.Text = string.Format("{0}", currentPage.GetProperty("pageTitle"));
            }
            else
            {
                title.Text = string.Format("{0}", currentPage.GetProperty("pageTitle"));
            }
        }
    }
}