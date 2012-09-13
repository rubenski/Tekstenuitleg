using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CursusIndex.data_logic;
using umbraco;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.web;
using umbraco.interfaces;

namespace CursusIndex.business_logic.business_objects
{
    public class GenericNodeBo : IGenericNodeBo
    {
        private readonly IGenericNodeDao _genericNodeDao = DaoFactory.GetUmbracoDaoFactory().GetGenericNodeDao();

        public IEnumerable<INode> FindDescendants(INode node)
        {
            return _genericNodeDao.FindDescendants(node);
        }

        public IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes)
        {
            return _genericNodeDao.FindDescendants(node, restrictDocTypes);
        }

        public IEnumerable<INode> FindAncestors(INode node)
        {
            return _genericNodeDao.FindAncestors(node);
        }

        public IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes)
        {

            return _genericNodeDao.FindAncestors(node, restrictDocTypes);
        }

        public IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes, List<int> restrictLevels)
        {
            return _genericNodeDao.FindAncestors(node, restrictDocTypes, restrictLevels);
        }

        public IEnumerable<INode> FindNodesByName(string name)
        {
            return _genericNodeDao.FindNodesByName(name);
        }

        
        

        public IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes, List<int> restrictLevels)
        {
            return _genericNodeDao.FindDescendants(node, restrictDocTypes, restrictLevels);
        }

        public IEnumerable<INode> FindNodesByType(INode rootINode, List<string> typeNames)
        {
            return _genericNodeDao.FindNodesByType(rootINode, typeNames);
        }

        public IEnumerable<INode> FindNodes(string nodeName, string nodeTypeAlias)
        {
            return _genericNodeDao.FindNodes(nodeName, nodeTypeAlias);
        }

        public string SubtreeAsHtmlList(INode rootNode, INode currentNode, bool includeRootNode, IList<string> restrictDocTypes = null)
        {
            return SubtreeAsHtmlList(rootNode, 0, currentNode, includeRootNode, restrictDocTypes);
        }

        public string SubtreeAsHtmlList(INode rootNode, int levelsInMenu, INode currentNode, bool includeRootNode, IList<string> restrictDocTypes = null)
        {
            IList<string> docTypes = new List<string>();
            if (restrictDocTypes == null || restrictDocTypes.Count == 0)
            {
                docTypes = DocumentType.GetAllAsList().Select(type => type.Alias).ToList();
            }else
            {
                docTypes = restrictDocTypes;
            }

            
            if(includeRootNode)
            {
                StringBuilder menuString = new StringBuilder();
                menuString.Append("<ul>");
                menuString.Append("<li>");
                menuString.Append("<a href=\"" + umbraco.library.NiceUrl(rootNode.Id) + "\">" + rootNode.Name + "</a>");
                menuString.Append(CreateListRecursive(rootNode, levelsInMenu, currentNode, docTypes, new StringBuilder()));
                menuString.Append("</li>");
                menuString.Append("</ul>");
                return menuString.ToString();
            }

            return CreateListRecursive(rootNode, levelsInMenu, currentNode, docTypes, new StringBuilder());
        }

        // Prints nodes under the the supplied node as an Html unordered list
        private string CreateListRecursive(INode node, int levelsInMenu, INode currentNode, IList<string> restrictDocTypes, StringBuilder htmlString)
        {
            IList<INode> allowedChildren = meetsTypeRestriction(node.ChildrenAsList, restrictDocTypes);
            if(allowedChildren.Count > 0)
            {
                htmlString.Append(Regex.Split(currentNode.Path, ",").Contains(node.Id.ToString())
                                      ? "<ul class=\"pathToCurrent\">"
                                      : "<ul>");
                foreach (INode n in allowedChildren)
                {
                    htmlString.Append(n.Id == currentNode.Id ? "<li class=\"current\">" : "<li>");
                    htmlString.Append("<a href='" + umbraco.library.NiceUrl(n.Id) + "'>");
                    htmlString.Append(n.Name);
                    htmlString.Append("</a>");
                    if (n.ChildrenAsList.Count > 0 && (levelsInMenu  == 0 || n.Level <= levelsInMenu + 1))
                    {
                        CreateListRecursive(n, levelsInMenu, currentNode, restrictDocTypes, htmlString);
                    }
                    htmlString.Append("</li>");
                }
                htmlString.Append("</ul>");    
            }

            return htmlString.ToString();
        }

        private IList<INode> meetsTypeRestriction(IEnumerable<INode> nodes, IList<string> restrictDocTypes)
        {
            return nodes.Cast<INode>().Where(node => restrictDocTypes.Contains(node.NodeTypeAlias)).ToList();
        }
    }
}