using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CursusIndex.util;
using CursusIndex.util.ordering;
using umbraco.interfaces;

namespace CursusIndex.business_logic.business_objects
{
    public interface ICategoryBo
    {
        List<INode> FindThemedCategoryArticles(INode theme, NodeOrder order = NodeOrder.DateAndTimeDescending, int startAt = 0);
        List<INode> FindAllCategoryArticles(INode category, NodeOrder order = NodeOrder.DateAndTimeDescending, int startAt = 0);
        INode FindCurrentSection(INode currentPage);


    }
}
