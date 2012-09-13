using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.interfaces;
using CursusIndex.business_logic.entitities;

namespace CursusIndex.business_logic.business_objects
{
    public interface IArticleBo
    {
        List<ArticleListItem> FindFullArticle(INode articlePage);
    }
}
