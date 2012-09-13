using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using umbraco.NodeFactory;
using umbraco.interfaces;
using umbraco.cms.businesslogic.web;

namespace CursusIndex.business_logic.business_objects
{
    public interface IThemeBo
    {
        INode FindCurrentlySelectedTheme(HttpRequest request, INode category);
        List<INode> FindPossibleThemesForArticle(Document doc);
    }
}
