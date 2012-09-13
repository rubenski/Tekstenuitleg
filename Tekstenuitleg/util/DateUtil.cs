using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using umbraco;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace CursusIndex.util
{
    public class DateUtil
    {
        public static string GetLocalizedCreateDate(INode node)
        {
            var culture = new CultureInfo(library.GetCurrentDomains(Node.getCurrentNodeId()).FirstOrDefault().Language.CultureAlias);
            var postDate = node.CreateDate;
            return postDate.ToString("f", culture);
        }


    }
}