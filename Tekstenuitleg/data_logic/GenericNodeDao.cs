using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using CursusIndex.util;
using umbraco;
using umbraco.Linq.Core;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.web;
using umbraco.interfaces;
using umbraco.presentation.translation;

namespace CursusIndex.data_logic
{
    public class GenericNodeDao : IGenericNodeDao
    {
        public IEnumerable<INode> FindNodes(string nodeName, string nodeTypeAlias)
        {
            if (String.IsNullOrEmpty(nodeName))
            {
                throw new ArgumentNullException("Null nodeName argument is not allowed in FindNodes");
            }

            if (String.IsNullOrEmpty(nodeTypeAlias))
            {
                throw new ArgumentNullException("Null nodeTypeAlias argument is not allowed in FindNodes");
            }

            return FetchAsNodes("//root/descendant-or-self::* [@isDoc and name()='" + nodeTypeAlias
                                + "' and @nodeName = '" + nodeName + "']");
        }

        public IEnumerable<INode> FindDescendants(INode node)
        {
            return FindAncestorsOrDescendants(node, false);
        }

        public IEnumerable<INode> FindDescendants(INode node, List<int> restrictDocTypes)
        {
            return FindAncestorsOrDescendants(node, false, restrictDocTypes);
        }

        public IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes)
        {
            return FindAncestorsOrDescendants(node, false, FindExistingDocTypeIds(restrictDocTypes));
        }

        public IEnumerable<INode> FindDescendants(INode node, List<int> restrictDocTypes, List<int> restrictLevels)
        {
            return FindAncestorsOrDescendants(node, false, restrictDocTypes, ValidateLevelsRestriction(restrictLevels));
        }

        public IEnumerable<INode> FindDescendants(INode node, List<string> restrictDocTypes, List<int> restrictLevels)
        {
            return FindAncestorsOrDescendants(node, false, FindExistingDocTypeIds(restrictDocTypes), ValidateLevelsRestriction(restrictLevels));
        }

        public IEnumerable<INode> FindAncestors(INode node)
        {
            return FindAncestorsOrDescendants(node, true);
        }

        public IEnumerable<INode> FindAncestors(INode node, List<int> restrictDocTypes)
        {
            return FindAncestorsOrDescendants(node, true, restrictDocTypes);
        }

        public IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes)
        {
            return FindAncestorsOrDescendants(node, true, FindExistingDocTypeIds(restrictDocTypes));
        }

        public IEnumerable<INode> FindAncestors(INode node, List<int> restrictDocTypes, List<int> restrictLevels)
        {
            return FindAncestorsOrDescendants(node, true, restrictDocTypes, restrictLevels);
        }

        public IEnumerable<INode> FindAncestors(INode node, List<string> restrictDocTypes, List<int> restrictLevels)
        {
            return FindAncestorsOrDescendants(node, true, FindExistingDocTypeIds(restrictDocTypes), ValidateLevelsRestriction(restrictLevels));
        }

        // TODO: this could be included in the FindAncestorsOrDescendants method. The difference here is that FindAncestorsOrDescendants looks for
        // actual documents (@isDoc) and FindFolderByName does not. 
        public IEnumerable<INode> FindNodesByName(string name)
        {
            string xPathQuery = "/root/descendant::* [@nodeName='" + name + "']";
            return FetchAsNodes(xPathQuery);
        }

        private IEnumerable<INode> FindAncestorsOrDescendants(INode node, bool ancestors, List<int> restrictDocTypes = null, List<int> restrictLevels = null)
        {

            if (node == null)
            {
                throw new ArgumentException("Cannot find ancestors or descendants of a NULL node");
            }

            string ancestorsOrDescendants = ancestors ? "ancestor-or-self" : "descendant-or-self";
            var docTypeRestriction = new StringBuilder();
            var levelsRestriction = new StringBuilder();
            string xPathFilter = "@isDoc";

            if (restrictDocTypes != null && restrictDocTypes.Count > 0)
            {
                for (int i = 0; i < restrictDocTypes.Count; i++)
                {
                    docTypeRestriction.Append(string.Format("@nodeType = {0}", restrictDocTypes[i]));
                    if (i + 1 < restrictDocTypes.Count)
                    {
                        docTypeRestriction.Append(string.Format(" or "));
                    }
                }
            }

            if (restrictLevels != null && restrictLevels.Count > 0)
            {
                for (int i = 0; i < restrictLevels.Count; i++)
                {
                    levelsRestriction.Append(string.Format("@level = {0}", restrictLevels[i]));
                    if (i + 1 < restrictLevels.Count)
                    {
                        levelsRestriction.Append(string.Format(" or "));
                    }
                }
            }


            if (docTypeRestriction.ToString().Length > 0)
            {
                xPathFilter += " and (" + docTypeRestriction.ToString() + ")";
            }

            if (levelsRestriction.ToString().Length > 0)
            {
                xPathFilter += " and (" + levelsRestriction.ToString() + ")";
            }

            xPathFilter = "[" + xPathFilter + "]";

            string xPathQuery = "/descendant::* [@id = " + node.Id + "]/" + ancestorsOrDescendants + "::* " + xPathFilter;

            return FetchAsNodes(xPathQuery);
        }


        private IEnumerable<INode> FetchAsNodes(string xPathQuery)
        {
            XPathNodeIterator iterator = library.GetXmlNodeByXPath(xPathQuery);
            IList<INode> nodes = new List<INode>();

            while (iterator.MoveNext())
            {
                XPathNavigator navigator = iterator.Current;
                if (navigator != null)
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(navigator.OuterXml);
                    string id = navigator.GetAttribute("id", "");
                    int nodeId = -10;
                    int.TryParse(id, out nodeId);
                    nodes.Add(new Node(nodeId));
                }
            }


            return nodes;
        }


        public IEnumerable<INode> FindNodesByType(INode rootNode, List<string> typeNames)
        {
            return FindNodesByType(rootNode, typeNames, new List<INode>());
        }

        private IEnumerable<INode> FindNodesByType(INode rootNode, List<string> typeNames, List<INode> items, bool firstIteration = true)
        {

            if (typeNames.Contains(rootNode.NodeTypeAlias) && firstIteration)
            {
                items.Add(rootNode);
            }

            foreach (INode childNode in rootNode.ChildrenAsList)
            {
                if (typeNames.Contains(childNode.NodeTypeAlias))
                {
                    items.Add(childNode);
                }
                if (childNode.ChildrenAsList.Count > 0)
                {
                    FindNodesByType(childNode, typeNames, items, false);
                }
            }

            return items;
        }

        private List<int> ValidateDocTypeRestriction(List<string> docTypes)
        {
            if (docTypes == null || docTypes.Count() == 0)
            {
                throw new ArgumentException("A doc type restriction cannot be null or empty");
            }

            List<int> existingDocTypes = FindExistingDocTypeIds(docTypes);

            if (existingDocTypes.Count < docTypes.Count)
            {
                throw new ArgumentException("restrictDocTypes contains doc types that don't exist");
            }

            return existingDocTypes;
        }

        private List<int> FindExistingDocTypeIds(IEnumerable<string> docTypes)
        {
            return docTypes.Select(docType => DocumentType.GetByAlias(docType).Id).ToList();
        }

        private List<int> ValidateLevelsRestriction(List<int> levels)
        {
            if (levels == null || levels.Count == 0)
            {
                throw new ArgumentException("A levels restriction cannot be null or empty");
            }

            return levels;
        }

    }
}