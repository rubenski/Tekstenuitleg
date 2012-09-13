using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursusIndex.util.ordering;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic.web;
using umbraco.interfaces;
using CursusIndex.data_logic;
using umbraco.NodeFactory;
using CursusIndex.util;

namespace CursusIndex.business_logic.business_objects
{
    public class BlogBo : IBlogBo
    {
        IGenericNodeDao nodeDao = DaoFactory.GetUmbracoDaoFactory().GetGenericNodeDao();

        public List<INode> FindLatestBlogPosts(NodeOrder order)
        {
            INode blogHome = FindBlogHome();
            if (blogHome == null)
            {
                throw new Exception("Blog home was not found");
            }
            IEnumerable<INode> blogPosts = nodeDao.FindDescendants(FindBlogHome(), new List<string> { "BlogPost" }, new List<int> { 3 });
            if (order.Equals(NodeOrder.DateAndTimeDescending))
            {
                blogPosts = OrderingUtil.OrderByCreateDate(blogPosts, Order.Descending);
            }
            else
            {
                blogPosts = OrderingUtil.OrderByCreateDate(blogPosts, Order.Ascending);
            }
            
            return blogPosts.ToList();
        }

        public INode AddComment(INode blogPost, string name, string email, string message)
        {
            INode commentsFolder = nodeDao.FindDescendants(blogPost, new List<string> {"BlogCommentsFolder"}).FirstOrDefault();
            if (commentsFolder == null)
            {
                commentsFolder = CreateCommentsFolder(blogPost);
            }

            Document newComment = Document.MakeNew("Comment by " + name, DocumentType.GetByAlias("BlogComment"),
                                                   User.GetAllByLoginName("visitor", false).FirstOrDefault(),
                                                   commentsFolder.Id);

            newComment.getProperty("name").Value = name;
            newComment.getProperty("email").Value = email;
            newComment.getProperty("message").Value = message;

            return SaveDoc(newComment);

        }



        private INode CreateCommentsFolder(INode blogPost)
        {
            Document commentsFolder = Document.MakeNew("Comments", DocumentType.GetByAlias("BlogCommentsFolder"),
                                                   User.GetAllByLoginName("rubenski", false).FirstOrDefault(),
                                                   blogPost.Id);
            return SaveDoc(commentsFolder);
        }

        private INode SaveDoc(Document doc)
        {
            doc.Save();
            doc.Publish(User.GetAllByLoginName("visitor", false).FirstOrDefault());
            umbraco.library.UpdateDocumentCache(doc.Id);
            return new Node(doc.Id);
        }

        public List<INode> FindComments(INode blogPost)
        {
            return OrderingUtil.OrderByCreateDate(nodeDao.FindDescendants(blogPost, new List<string> {"BlogComment"}), Order.Ascending);
        }

        private INode FindBlogHome()
        {
            INode homepage = SiteUtil.FindCurrentHomepage();
            return nodeDao.FindDescendants(homepage, new List<string> { "BlogHome" }, new List<int> { 2 }).FirstOrDefault();
        }
    }
}