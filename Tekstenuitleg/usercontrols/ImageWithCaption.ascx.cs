using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using CursusIndex.business_logic.entitities;
using CursusIndex.util;
using umbraco;

namespace Tekstenuitleg.usercontrols
{
    public partial class ImageWithCaption : System.Web.UI.UserControl
    {
        public int TheImage { get; set; }
        public string CaptionText { get; set; }
        public UmbracoImage image;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ImageWithCaption()
        {
            // At this point TheIamge is 0 and CaptionText is null. Why?
            Log.Debug("TheImage: " + TheImage);
            Log.Debug("CaptionText: " + CaptionText);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // This is never hit
            Log.Debug("TheImage in onload: " + TheImage);
            Log.Debug("CaptionText in onload: " + CaptionText);

            XPathNodeIterator iterator =  library.GetMedia(TheImage, false);
            UmbracoImage image = UmbracoFieldReader.ReadMediaImageFromIterator(iterator);
        }
    }
}