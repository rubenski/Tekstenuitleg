using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

using umbraco;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic.web;

namespace Tekstenuitleg.usercontrols
{
    public partial class ArticleImporter : System.Web.UI.UserControl
    {

        List<string> Words = new List<string>();
        List<Document> NewDocs = new List<Document>(); 

        protected void Page_Load(object sender, EventArgs e)
        {

            var sectionMapping = new Dictionary<int, Object[]>();
            sectionMapping.Add(35, new Object[2]{1261, "netwerken"});
            sectionMapping.Add(36, new Object[2] { 1256, "internet" });
            sectionMapping.Add(37, new Object[2] { 1263, "software" });
            sectionMapping.Add(38, new Object[2] { 1262, "hardware" });
            sectionMapping.Add(45, new Object[2] { 1282, "networking" });
            sectionMapping.Add(46, new Object[2] { 1280, "internet" });
            sectionMapping.Add(48, new Object[2] { 1281, "software" });
            sectionMapping.Add(49, new Object[2] { 1279, "hardware" });


            string MyConString = "SERVER=127.0.0.1;" +
                "DATABASE=tu;" +
                "UID=root;" +
                "PASSWORD=smeerkaas;";
            var connection = new MySqlConnection(MyConString);
            connection.Open();

            var articles = new Dictionary<int, AlmostArticle>();
            foreach(KeyValuePair<int, Object[]> pair in sectionMapping)
            {
                var fetchArticleCommand = new MySqlCommand("select * from article where section_id = " + pair.Key + " order by create_date asc" , connection);
                MySqlDataReader articleReader = fetchArticleCommand.ExecuteReader();
                
                while(articleReader.Read())
                {
                    DateTime createDate = DateTime.Now;
                    try
                    {
                        createDate = articleReader.GetDateTime("create_date"); 
                    }catch(Exception ex)
                    {
                        
                    }

                    // Create an almost article
                    var article = new AlmostArticle(articleReader.GetInt32("id"), createDate,
                                                    articleReader.GetString("listintro"),
                                                    articleReader.GetString("urlname"), 
                                                    int.Parse(pair.Value[0].ToString()),
                                                    articleReader.GetString("art_title"),
                                                    pair.Value[1].ToString());

                    articles.Add(articleReader.GetInt32("id"), article);
                }
                articleReader.Close();

            }
       
            connection.Close();

            foreach(KeyValuePair<int, AlmostArticle> articlePair in articles)
            {
                var connection1 = new MySqlConnection(MyConString);
                connection1.Open();
                var pages = new MySqlCommand("select * from article_page where article_id = " + articlePair.Key + " order by pagenumber asc", connection1);
                MySqlDataReader pagesReader = pages.ExecuteReader();
                var newArticleDocs = new Dictionary<int, Document>();
                
                while(pagesReader.Read())
                {
                    int pagenumber = pagesReader.GetInt32("pagenumber");
                    AlmostArticle article = articlePair.Value;
                    string name = pagesReader.GetString("urlname");


                    if(pagenumber == 1)
                    {

                        DocumentType articleType = DocumentType.GetByAlias("Article");

                        Document newArticle = Document.MakeNew(
                            article.title,
                            articleType, 
                            new User(5), 
                            article.sectionId);

                        newArticle.getProperty("body").Value = pagesReader.GetString("pagetext");
                        newArticle.getProperty("pageTitle").Value = pagesReader.GetString("page_title");
                        newArticle.getProperty("teaser").Value = articlePair.Value.teaser;
                        newArticle.getProperty("metaDescription").Value = pagesReader.GetString("metadescription");
                        // Prepare the alias name for the Article
                        string alias = "artikelen/" + article.sectionName + "/" + article.urlName + "/" + name;
                        newArticle.getProperty("umbracoUrlAlias").Value = alias;
                        newArticleDocs.Add(articlePair.Key, newArticle);
                        NewDocs.Add(newArticle);
                        

                        SaveDoc(newArticle);
                        
                        
                    }else
                    {
                        Document newSubPage = Document.MakeNew(pagesReader.GetString("page_title"),
                                                               DocumentType.GetByAlias("ArticleSubPage"), 
                                                               new User(5), 
                                                               newArticleDocs[articlePair.Key].Id);

                        newSubPage.getProperty("body").Value = pagesReader.GetString("pagetext");
                        newSubPage.getProperty("pageTitle").Value = pagesReader.GetString("page_title");
                        newSubPage.getProperty("positionInArticle").Value = pagesReader.GetInt32("pagenumber");
                        newSubPage.getProperty("metaDescription").Value = pagesReader.GetString("metadescription");
                        // Prepare the alias name for the Article
                        string alias = "artikelen/" + article.sectionName + "/" + article.urlName + "/" + name;
                        newSubPage.getProperty("umbracoUrlAlias").Value = alias;

                        NewDocs.Add(newSubPage);

                        SaveDoc(newSubPage);
                    }
                }
                connection1.Close();
            }
            
            foreach(Document d in NewDocs)
            {
                d.getProperty("body").Value = UnFuckText(d.getProperty("body").Value.ToString());
                SaveDoc(d);
            }

            foreach(string w in Words)
            {
                Response.Write(w + "<br>");
            }
        }

        private void SaveDoc(Document doc)
        {
            doc.Save();
            doc.Publish(User.GetCurrent());
            umbraco.library.UpdateDocumentCache(doc.Id);
        }

        private string UnFuckText(string pageText)
        {

            Response.Write("<BR><BR>NEW PAGE<br><br>");

            pageText = pageText.Replace("[ulist]", "<ul>");
            pageText = pageText.Replace("[/ulist]", "</ul>");

            pageText = pageText.Replace("[olist]", "<ol>");
            pageText = pageText.Replace("[/olist]", "</ol>");

            pageText = pageText.Replace("[strong]", "<strong>");
            pageText = pageText.Replace("[/strong]", "</strong>");

            pageText = pageText.Replace("[li]", "<li>");
            pageText = pageText.Replace("[/li]", "</li>");

            pageText = pageText.Replace("[i]", "<i>");
            pageText = pageText.Replace("[/i]", "</i>");

            pageText = pageText.Replace("[em]", "<em>");
            pageText = pageText.Replace("[/em]", "</em>");

            pageText = pageText.Replace("[b]", "<b>");
            pageText = pageText.Replace("[/b]", "</b>");

            pageText = pageText.Replace("[quote]", "<blockquote>");
            pageText = pageText.Replace("[/quote]", "</blockquote>");

            pageText = pageText.Replace("[h1]", "<h1>");
            pageText = pageText.Replace("[/h1]", "</h1>");

            pageText = pageText.Replace("[h2]", "<h2>");
            pageText = pageText.Replace("[/h2]", "</h2>");

            pageText = pageText.Replace("[h3]", "<h3>");
            pageText = pageText.Replace("[/h3]", "</h3>");

            pageText = pageText.Replace("[h4]", "<h4>");
            pageText = pageText.Replace("[/h4]", "</h4>");

            pageText = pageText.Replace("[p]", "<p>");
            pageText = pageText.Replace("[/p]", "</p>");


            MatchCollection matches = Regex.Matches(pageText, @"\[url(.*?)\](.*?)\[/url\]");
            var replaceAnchors = new Dictionary<string, string>();
            foreach (var match in matches)
            {
                string anchor = extractAnchor(match.ToString());
                if(!replaceAnchors.ContainsKey(match.ToString()))
                {
                    replaceAnchors.Add(match.ToString(), anchor);
                }
                
            }
            foreach (var replaceAnchor in replaceAnchors)
            {
                pageText = pageText.Replace(replaceAnchor.Key, replaceAnchor.Value);
            }

            MatchCollection imgMatches = Regex.Matches(pageText, @"\[img(.*?)\](.*?)\[/img\]");
            var replaceImages = new Dictionary<string, string>();
            foreach (var imgMatch in imgMatches)
            {
                string img = extractImage(imgMatch.ToString());
                if(!replaceImages.ContainsKey(imgMatch.ToString()))
                {
                    replaceImages.Add(imgMatch.ToString(), img);
                }
            }

            foreach (var replaceImage in replaceImages)
            {
                pageText = pageText.Replace(replaceImage.Key, replaceImage.Value);
            }

            return pageText;
        }

        private string extractAnchor(string txt)
        {
            // "[url=/artikelen/netwerken/netwerk-aanleggen/intro.html]Een netwerk aanleggen[/url]"
            // string url1 = Regex.Match(txt, @"url=([.*]+)[\]|\w]").ToString().Replace("url=","").Replace("\"","");

            string url = Regex.Match(txt, @"url=(.*?)[\]|\s]").ToString().Trim().Replace("\"", "").Replace("url=", "").Replace("]", "");
            string target = Regex.Match(txt, @"target(.*?)\]").ToString().Trim().Replace("target", "").Trim().Replace("=", "").Replace("\"", "").Replace("]", "").Replace("&quot;", "\"");
            string linkText = Regex.Match(txt, @"\](.*?)\[").ToString().Trim().Replace("[", "").Replace("]", "").Trim();
            string link = "<a href=\"" + url + "\" target=" + target  + ">" + linkText + "</a>";
            return link;
        }

        private string extractImage(string txt)
        {

            string alt = Regex.Match(txt, @"alt=(.*?)\s").ToString().Trim();
            string width = Regex.Match(txt, @"w=(.*?)\s").ToString().Replace("w=", "").Trim();
            string height = Regex.Match(txt, @"h=(.*?)[\s|\]]").ToString().Replace("h=", "").Trim();
            string url = Regex.Match(txt, @"\](.*?)\[").ToString().Trim().Replace("[", "").Replace("]", "");

            alt = alt.Replace("alt=", "alt=\"");
            alt += "\"";

            if(!string.IsNullOrEmpty(width))
            {
                width = "width=" + width;
                width = "\"" + width + "\"";
            }

            if (!string.IsNullOrEmpty(height))
            {
                height = height.Replace("]", "");
                height = "\"" + height + "\"";
                height = "height=" + height;
            }

            string img = "<img src=\"" + url  + "\" " + alt + " " + width + " " + height + "/>";

            return img;
        }

    }


    class AlmostArticle
    {
        public AlmostArticle(int _article_id,  DateTime create_date, string teasert,string url_name, int section_id, string art_title, string section_name)
        {
            teaser = teasert;
            articleId = _article_id;
            createDate = create_date;
            urlName = url_name;
            sectionId = section_id;
            title = art_title;
            sectionName = section_name;

        }

        public string teaser;
        public int articleId;
        public DateTime createDate;
        public string urlName;
        public int sectionId;
        public string title;
        public string sectionName;


    }
}