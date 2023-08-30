using Persistence;
using DAL;

namespace BL
{
    public class ClothesBL
    {
        ClothesDAL cDAL = new ClothesDAL();
        public List<Clothes> GetAllProduct()
        {
            return cDAL.GetProducts();
        }

    }
}