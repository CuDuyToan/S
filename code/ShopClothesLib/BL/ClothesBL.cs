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
        public Clothes GetProductByID(int id)
        {
            return cDAL.GetProductByID(id);
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