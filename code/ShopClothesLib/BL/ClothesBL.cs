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
        public void GetClothesByCategory(string categoryName, List<Categories> categories, List<Clothes> clothes, List<Size_color> szclList, List<Size> size, List<Color> color)
        {
            int category=0;
            string category_name = "";
            foreach (var item in categories)
            {
                if (item.Category_name == categoryName)
                {
                    category = item.ID;
                    category_name = item.Category_name;
                }
            }
            cDAL.GetClothesByCategory(category, category_name, clothes, szclList, size, color);
        }

        public string getInfoClothes(int ID, List<Categories> categories, List<Clothes> clothes, List<Size_color> szclList, List<Size> size, List<Color> color)
        {
            string nameClothes="";
            foreach (Clothes item in clothes)
            {
                if (item.ID == ID)
                {
                    nameClothes = cDAL.getInfoClothes(item, categories, clothes, szclList, size, color);
                    break;
                }
            }
            return nameClothes;
        }


        public decimal GetPriceByProductName(string productName)
        {
            List<Clothes> products = cDAL. GetProducts();
            foreach (Clothes product in products)
            {
                if(product.Name == productName)
                return product.Unit_price;
            }
            return 0;
        }

        public List<rowPageSpl> ShowListClothes(List<Clothes> ListClothes, List<Size_color> List_szcl, List<Size> ListSize, List<Color> ListColor, List<Categories> ListCategory, int page, int row)
        {
            return cDAL.ListClothes(ListClothes, List_szcl, ListSize, ListColor, ListCategory, page, row);
        }
        // public Order AddToOrder(int ID)
        // {
        //     return AddToOrder();
        // }
    }
}