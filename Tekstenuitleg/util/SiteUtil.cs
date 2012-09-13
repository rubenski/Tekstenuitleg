using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using CursusIndex.data_logic;
using umbraco;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.language;
using umbraco.cms.businesslogic.web;
using umbraco.interfaces;

namespace CursusIndex.util
{
    public class SiteUtil
    {
        private static IGenericNodeDao nodeDao = DaoFactory.GetUmbracoDaoFactory().GetGenericNodeDao();

        public static INode FindCurrentHomepage()
        {
            Domain[] domains = library.GetCurrentDomains(Node.getCurrentNodeId());

            if (domains != null)
            {
                Language language = domains[0].Language;
                string cultureAlias = language.CultureAlias;
                return FindHomepages()[cultureAlias];
            }
            
            // This is a last resort fallback procedure that is only used on the 404 page, because there the domains are not accessible
            return FindHomepageByRequest(HttpContext.Current.Request);
        }
        
        
        private static INode FindHomepageByRequest(HttpRequest request)
        {
            string[] browserLanguages = request.UserLanguages;
            var browserLanguageCodes = browserLanguages.Select(browserLanguage => browserLanguage.Substring(0, 2)).ToList();
            IEnumerable<Language> siteLanguages = Language.GetAllAsList();

            foreach(var siteLanguage in siteLanguages)
            {
                foreach (var browserLanguageCode in browserLanguageCodes)
                {
                    if (siteLanguage.CultureAlias.StartsWith(browserLanguageCode))
                    {
                        return FindHomepages()[siteLanguage.CultureAlias];
                    }
                }
            }

            // If all else fails, return the en-US homepage.
            return FindHomepages()["en-US"];
        }

       

        private static Dictionary<string, INode> FindHomepages()
        {
            IEnumerable<INode> homepages = nodeDao.FindDescendants(new Node(-1), new List<string> { "Homepage" }, new List<int> { 1 });
            var homepageDictionary = new Dictionary<string, INode>();
            foreach (var homepage in homepages)
            {
                Domain domains = library.GetCurrentDomains(homepage.Id).FirstOrDefault();
                homepageDictionary.Add(domains.Language.CultureAlias, homepage);
            }
            return homepageDictionary;
        }
    }
}