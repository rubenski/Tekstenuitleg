using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace ImageAlignmentMacroParameter
{
    public class ImageAlignment : DropDownList, IMacroGuiRendering
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Items.Count == 0)
            {
                this.Items.Add(new ListItem("Inline left", "inlineleft"));
                this.Items.Add(new ListItem("Center", "center"));
                this.Items.Add(new ListItem("Inline right", "inlineright"));
            }
        }

        public bool ShowCaption
        {
            get { return true; }
        }

        public string Value
        {
            get
            {
                return this.SelectedValue;
            }
            set
            {
                this.SelectedValue = value;
            }
        }
    }
}
