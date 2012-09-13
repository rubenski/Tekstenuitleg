using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursusIndex.util;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace CursusIndex.business_logic.entitities
{
    public class PageNode
    {
        public PageNode(INode node)
        {
            Id = node.Id;
            NiceUrl = node.NiceUrl;
            NodeName = node.Name;
            PageTitle = UmbracoFieldReader.ReadStringField(node.GetProperty("pageTitle"));
            NodeTypeAlias = node.NodeTypeAlias;
        }

        public int Id { get; set; }
        public string NiceUrl { get; set; }
        public string NodeName { get; set; }
        public string PageTitle { get; set; }
        public string NodeTypeAlias { get; set; }
    }
}