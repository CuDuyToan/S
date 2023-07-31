using Persistence;
using DAL;

namespace BL
{
    public class CategoryBL
    {
        CategoryDAL cgrDAL = new CategoryDAL();
        public List<Categories> GetCategories()
        {
            return cgrDAL.GetListCategories();
        }
    }
}