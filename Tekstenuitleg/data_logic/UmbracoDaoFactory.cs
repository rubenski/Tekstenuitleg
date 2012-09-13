using System;

namespace CursusIndex.data_logic
{
    public class UmbracoDaoFactory
    {
        public IArticleDao GetArticleDao()
        {
            return new ArticleDao();
        }

        public IGenericNodeDao GetGenericNodeDao()
        {
            return new GenericNodeDao();
        }
    }
}