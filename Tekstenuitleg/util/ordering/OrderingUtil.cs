using System.Collections.Generic;
using System.Linq;
using umbraco.interfaces;

namespace CursusIndex.util.ordering
{

    public enum Order
    {
        Descending,
        Ascending
    }

    public class OrderingUtil
    {
        public static List<INode> OrderByNumericProperty(IEnumerable<INode> nodes, string propertyName, Order order)
        {
            var emptyNodes = new List<INode>();
            var nonEmptyNodes = new List<INode>();

            foreach (var node in nodes)
            {
                IProperty p = node.GetProperty(propertyName);
                if (p != null && !string.IsNullOrEmpty(p.Value))
                {
                    nonEmptyNodes.Add(node);
                }else
                {
                    emptyNodes.Add(node);
                }
            }

            if(order.Equals(Order.Ascending))
            {
                return nonEmptyNodes.OrderBy(x => x.GetProperty(propertyName).Value).Concat(emptyNodes).ToList();
            }

            return nonEmptyNodes.OrderByDescending(x => x.GetProperty(propertyName).Value).Concat(emptyNodes).ToList();
        }

        public static List<INode> OrderByCreateDate(IEnumerable<INode> nodes, Order order)
        {
            if (order.Equals(Order.Descending))
            {
                return nodes.OrderByDescending(x => x.CreateDate).ToList();
            }

            return nodes.OrderBy(x => x.CreateDate).ToList();
        }
    }
}