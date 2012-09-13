using System.Collections.Generic;
using System.Linq;
using CursusIndex.business_logic.business_objects;
using Tekstenuitleg.business_logic.business_objects;
using umbraco;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.web;
using umbraco.interfaces;

namespace Tekstenuitleg.settings
{
    public class SettingsData
    {
        private static readonly Dictionary<string, INode> Homepages = new Dictionary<string, INode>();
        private static readonly IGenericNodeBo NodeBo = BusinessFactory.GetGenericNodeBo();
        private readonly INode _currentPage;
        private readonly string _currentLanguage = "";
        private INode _currentCategory;


        public SettingsData(INode currentPage)
        {
            _currentPage = currentPage;
            _currentLanguage = library.GetCurrentDomains(_currentPage.Id).FirstOrDefault().Language.FriendlyName;
        }

        public INode CurrentHomepage()
        {
            if (Homepages.Count == 0)
            {
                FindHomepages();
            }

            return (Homepages[_currentLanguage]);
        }

        public INode CurrentCategory()
        {
            if (_currentCategory == null)
            {
                if (_currentPage.NodeTypeAlias.Equals("Category"))
                {
                    _currentCategory = _currentPage;
                }
                else if (_currentPage.NodeTypeAlias.Equals("Article") || _currentPage.NodeTypeAlias.Equals("ArticleSubPage"))
                {
                    _currentCategory = NodeBo.FindAncestors(_currentPage, new List<string> { "Category" }, new List<int> { 3 }).FirstOrDefault();
                }
                else
                {
                    _currentCategory = null;
                }
            }

            return _currentCategory;

        }

        public string CurrentLanguage()
        {
            return _currentLanguage;
        }

        private static void FindHomepages()
        {
            IEnumerable<INode> homepages = NodeBo.FindDescendants(new Node(-1), new List<string> { "Homepage" }, new List<int> { 1 });
            foreach (var homepage in homepages)
            {
                Domain domains = library.GetCurrentDomains(homepage.Id).FirstOrDefault();
                Homepages.Add(domains.Language.CultureAlias, homepage);
            }
        }


    }
}