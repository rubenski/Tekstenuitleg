using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursusIndex.util;
using umbraco.NodeFactory;
using umbraco.interfaces;


namespace CursusIndex.business_logic.entitities
{
    public class ArticleListItem
    {
        public string PageTitle;
        public string ArticleTitle;
        public string TeaserText;
        public string Url;
        public UmbracoImage ListImage;
        public int Id;
        public DateTime CreateDate;

        public ArticleListItem(INode article)
        {
            ArticleTitle = UmbracoFieldReader.ReadStringField(article.GetProperty("articleTitle"));
            Id = article.Id;
            PageTitle = UmbracoFieldReader.ReadStringField(article.GetProperty("pageTitle"));
            TeaserText = UmbracoFieldReader.ReadStringField(article.GetProperty("teaser"));
            CreateDate = article.CreateDate;

            if (article.GetProperty("umbracoUrlAlias") != null && !string.IsNullOrEmpty(article.GetProperty("umbracoUrlAlias").Value))
            {
                Url = "/" + article.GetProperty("umbracoUrlAlias").Value + ".html";
            }else
            {
                Url = article.NiceUrl;
            }
           
            ListImage = UmbracoFieldReader.ReadMediaPickerImageField(article.GetProperty("listImage"));
        }
    }
}