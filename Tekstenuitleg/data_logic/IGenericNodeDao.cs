using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.Linq.Core;
using umbraco.interfaces;


namespace CursusIndex.data_logic
{
    public interface IGenericNodeDao
    {
        IEnumerable<INode> FindNodes(string nodeName, string nodeType);

        IEnumerable<INode> FindDescendants(INode node);
        IEnumerable<INode> FindDescendants(INode node, List<int> restrictDocTypes);
        IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes);
        IEnumerable<INode> FindDescendants(INode node, List<int> restrictDocTypes, List<int> restrictLevels);
        IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes, List<int> restrictLevels);

        IEnumerable<INode> FindAncestors(INode node);
        IEnumerable<INode> FindAncestors(INode node, List<int> restrictDocTypes);
        IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes);
        IEnumerable<INode> FindAncestors(INode node, List<int> restrictDocTypes, List<int> restrictLevels);
        IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes, List<int> restrictLevels);

        IEnumerable<INode> FindNodesByName(string name);

        IEnumerable<INode> FindNodesByType(INode rootINode , List<string> typeNames);
    }
}
