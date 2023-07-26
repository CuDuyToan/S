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
        public List<Clothes> GetProductsByCategory(string category)
        {
            return cDAL.GetProductsByCategory(category);
        }
        public decimal GetPriceByProductName(string productName)
        {
            List<Clothes> products = cDAL. GetProducts();
            foreach (Clothes product in products)
            {
                if(product.Name == productName)
                return product.Price;
            }
            return 0;
        }

    }
}