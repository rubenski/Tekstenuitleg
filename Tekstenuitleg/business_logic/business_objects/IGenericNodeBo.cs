using System.Collections.Generic;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace CursusIndex.business_logic.business_objects
{
    public interface IGenericNodeBo
    {
        // string SubtreeAsHtmlList(Node rootNode, int levelsInMenu, Node currentNode, bool includeRootNode, IList<string> restrictDocTypes = null);
        // string SubtreeAsHtmlList(Node rootNode, Node currentNode, bool includeRootNode, IList<string> restrictDocTypes = null);

        IEnumerable<INode> FindAncestors(INode node);
        IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes);
        IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes, List<int> restrictLevels);

        IEnumerable<INode> FindDescendants(INode node);
        IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes);
        IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes, List<int> restrictLevels);

        IEnumerable<INode> FindNodesByType(INode rootINode, List<string> typeNames);

        IEnumerable<INode> FindNodesByName(string name);

    }
}
