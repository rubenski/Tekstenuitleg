using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CursusIndex.util.ordering;
using umbraco.interfaces;
using CursusIndex.util;

namespace CursusIndex.business_logic.business_objects
{
    public interface IBlogBo
    {
        List<INode> FindLatestBlogPosts(NodeOrder order = NodeOrder.DateAndTimeDescending);
        INode AddComment(INode blogPost, string name, string email, string message);
        List<INode> FindComments(INode blogPost);
    }
}
