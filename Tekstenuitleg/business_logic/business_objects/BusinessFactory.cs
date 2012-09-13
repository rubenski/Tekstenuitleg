using CursusIndex.business_logic.business_objects;

namespace Tekstenuitleg.business_logic.business_objects
{
    public abstract class BusinessFactory
    {
        public static IGenericNodeBo GetGenericNodeBo()
        {
            return new GenericNodeBo();
        }

        public static IThemeBo GetThemeBo()
        {
            return new ThemeBo();
        }

        public static ICategoryBo GetCategoryBo()
        {
            return new CategoryBo();
        }

        public static IBlogBo GetBlogBo()
        {
            return new BlogBo();
        }

        public static IArticleBo GetArticleBo()
        {
            return new ArticleBo();
        }

        public static ISecurityBo GetSecurityBo()
        {
            return new SecurityBo();
        }
    }
}