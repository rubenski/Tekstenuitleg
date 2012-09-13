using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tekstenuitleg.business_logic.business_objects;
using umbraco.editorControls.userControlGrapper;
using System.Data;
using umbraco.interfaces;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.web;
using CursusIndex.business_logic.business_objects;

namespace Tekstenuitleg.usercontrols
{
    public partial class ThemePickerDataType : System.Web.UI.UserControl, IUsercontrolDataEditor
    {
        private IThemeBo themeBo = BusinessFactory.GetThemeBo();

        public string UmbracoValue = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Wire up the dropdownlist and load the
                // data items
                ThemePickerListBox.DataSource = GetCategories();
                ThemePickerListBox.DataTextField = "Name";
                ThemePickerListBox.DataValueField = "NodeId";
                ThemePickerListBox.DataBind();
            }

            // if this is a postback, set the UmbracoValue
            // public property so we can reference the value
            // in the implemented interface below
            else if (Page.IsPostBack)
            {
                int[] indices = ThemePickerListBox.GetSelectedIndices();
                List<string> selectedNodeIds = new List<string>(); 

                foreach (ListItem item in ThemePickerListBox.Items)
                {
                    if (item.Selected)
                    {
                        selectedNodeIds.Add(item.Value);
                    }
                }

                UmbracoValue = string.Join(",", selectedNodeIds);
            }

            // If there is a saved value, always set it as the
            // [selected] value of the control
            if (!UmbracoValue.Equals(""))
            {
                //ThemePickerListBox.Items.FindByValue(UmbracoValue).Selected = true;
                foreach (string idString in UmbracoValue.Split(','))
                {
                    if (ThemePickerListBox.Items.FindByValue(idString) != null)
                    {
                        ThemePickerListBox.Items.FindByValue(idString).Selected = true;
                    }
                }
            }
        }

        private DataTable GetCategories()
        {
            string nodeid = Request.QueryString["id"];
            Document doc = new Document(Convert.ToInt32(nodeid));

            List<INode> themes = themeBo.FindPossibleThemesForArticle(doc);

            DataTable themeTable = new DataTable();
            themeTable.Columns.Add("NodeId", Type.GetType("System.Int32"));
            themeTable.Columns.Add("Name", Type.GetType("System.String"));
            foreach (var theme in themes)
            {
                DataRow row = themeTable.NewRow();
                row["NodeId"] = theme.Id;
                row["Name"] = theme.Name;
                themeTable.Rows.Add(row);
            }

            return themeTable;
        }

        #region IUsercontrolDataEditor Members
        public object value
        {
            get
            {
                // if there is no value, set the value to null
                // otherwise use the selected value
                return UmbracoValue;
            }
            set
            {
                // When the control is loaded in the backoffice,
                // check if there is a saved value. If so, set the
                // matching item in the dropdownlist to selected.
                if (value != null &&
                !String.IsNullOrEmpty(value.ToString()))
                {
                    UmbracoValue = value.ToString();
                }
            }
        }
        #endregion
    }
}