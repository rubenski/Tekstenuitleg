using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursusIndex.data_logic;
using umbraco.NodeFactory;
using umbraco.interfaces;
using umbraco.cms.businesslogic.web;
using System.Collections;

namespace CursusIndex.business_logic.business_objects
{
    public class ThemeBo : IThemeBo
    {
        private IGenericNodeDao nodeDao = DaoFactory.GetUmbracoDaoFactory().GetGenericNodeDao();

        public INode FindCurrentlySelectedTheme(HttpRequest request, INode category)
        {
            string path = request.Url.AbsolutePath.Substring(1);
            var themes = FindThemes(category);
            foreach (var theme in themes)
            {
                if(theme.GetProperty("umbracoUrlAlias").Value.Equals(path))
                {
                    return theme;
                }
            }
            return null;

        }

        public List<INode> FindThemes(INode category)
        {
            return nodeDao.FindDescendants(category, new List<string> { "Theme" }, new List<int> { 5 }).ToList();
        }

        public List<INode> FindPossibleThemesForArticle(Document doc)
        {
            string docType = doc.ContentType.Alias;
            var themes = new List<INode>();
            if (!docType.Equals("Article"))
            {
                throw new ArgumentException("Finding possible themes is only possible for the Article node type.");
            }

            string[] pathIds = (doc.Path.Split(','));

            foreach (var idString in pathIds)
            { 
                if (idString != "-1")
                {
                    int id = -10;
                    int.TryParse(idString, out id);
                    Document pathDoc = new Document(id);

                    if (pathDoc.ContentType.Alias.Equals("Category"))
                    {
                        // Only published themes are found, because we are using the Node API
                        themes = FindThemes(new Node(pathDoc.Id));
                    }
                }
                
            }

            return themes;  
        }
    }
}