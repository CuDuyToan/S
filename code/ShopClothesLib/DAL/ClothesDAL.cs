using Persistence;
using MySqlConnector;
namespace DAL;

public class ClothesDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    // tạo thêm một hàm select toàn bộ thông tin của clothes, staff, customer... từ db về
    public List<Clothes> GetProducts()
    {
        Clothes product = new Clothes();
        List<Clothes> products = new List<Clothes>();
        try
        {
            query = @"SELECT * FROM clothes_shop.clothes;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product = GetProduct(reader);
                products.Add(product);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return products;
    }
    public void GetClothesByCategory(int categoryID, string categoryName, List<Clothes> clothes, List<Size_color> szclList, List<Size> size, List<Color> color)
    {
        try
        {
            foreach (Clothes item in clothes)
            {
                if (item.Category_ID == categoryID)
                {
                    string sizeName ="", colorName="";
                    foreach (Size_color item_szcl in szclList)
                    {
                        if (item_szcl.clothes_ID == item.ID)
                        {
                            foreach (Size item_size in size)
                            {
                                if (item_size.Size_ID == item_szcl.Size_ID)
                                {
                                    sizeName = item_size.Size_Name;
                                }
                            }
                            foreach (Color item_color in color)
                            {
                                if (item_color.Color_ID == item_szcl.Color_ID)
                                {
                                    colorName = item_color.Color_Name;
                                }
                            }
                        }
                    }

                    Console.WriteLine("| {0,4} | {1, 50} | {2, 12} VNĐ | {3, 20} | {4, 4} | {5, 10} |", item.ID, item.Name, item.Unit_price, categoryName, sizeName, colorName);
                    Console.WriteLine("================================================================================================================================");
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string getInfoClothes(Clothes clothes, List<Categories> categories, List<Clothes> clothesList, List<Size_color> szclList, List<Size> size, List<Color> color)
    {
        string sizeName ="Size", colorName="color", categoryName="Category";
        int quantity = 0;
        foreach (Categories item in categories)
        {
            if (item.ID == clothes.Category_ID)
            {
                categoryName = item.Category_name;
                break;
            }
        }
        foreach (Size_color item in szclList)
        {
            if (item.clothes_ID == clothes.ID)
            {
                foreach (Size item_size in size)
                {
                    if (item.Size_ID == item_size.Size_ID)
                    {
                        sizeName = item_size.Size_Name;
                        break;
                    }
                }
                foreach (Color item_color in color)
                {
                    if (item.Color_ID == item_color.Color_ID)
                    {
                        colorName = item_color.Color_Name;
                        break;
                    }
                }
                quantity = item.Quantity;
                break;
            }
        }
        var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        string price = String.Format(info, "{0:N0}", clothes.Unit_price);
        Console.Clear();
        Console.WriteLine("ID:          {0}", clothes.ID);
        Console.WriteLine("Name:        {0}", clothes.Name);
        Console.WriteLine("Price:       {0} vnđ", price);
        Console.WriteLine("Category:    {0}", categoryName);
        Console.WriteLine("Material:    {0}", clothes.Material);
        Console.WriteLine("User Manual: {0}", clothes.user_manual);
        Console.WriteLine("Size:        {0}", sizeName);
        Console.WriteLine("Color:       {0}", colorName);
        Console.WriteLine("Quantity:    {0}", quantity);
        return clothes.Name;
    }
    public Clothes GetProductByID(int ID)
    {
        Clothes product = new Clothes();
        try
        {
            query = @"select  clothes.Clothes_ID, clothes.Clothes_Name, clothes.Unit_price,  clothes.Material, categories.category_name from clothes_shop.clothes inner join clothes_shop.categories on clothes.Category_ID = categories.category_ID where clothes.clothes_ID = @ID;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            MySqlDataReader reader = command.ExecuteReader();
            product = GetProduct(reader);
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return product;
    }

    public List<rowPageSpl> ListClothes(List<Clothes> ListClothes, List<Size_color> List_szcl, List<Size> ListSize, List<Color> ListColor, List<Categories> ListCategory, int page, int row)//List<rowPageSpl>
    {
        Clothes clothes = new Clothes();
        List<rowPageSpl> rowPageSpls = new List<rowPageSpl>();
        PageSplDAL rowpagDAL = new PageSplDAL();
        rowPageSpl rowpag = new rowPageSpl();
        string category = "", nameColor = "", nameSize = "";
        int count = 1;
        foreach (Clothes item in ListClothes)
        {
            foreach (Size_color item_szcl in List_szcl)
            {
                if (item.ID == item_szcl.clothes_ID)
                {
                    foreach (Size item_Size in ListSize)
                    {
                        if (item_szcl.Size_ID == item_Size.Size_ID)
                        {
                            nameSize=item_Size.Size_Name;
                            break;
                        }
                    }
                    foreach (Color item_Color in ListColor)
                    {
                        if (item_szcl.Color_ID == item_Color.Color_ID)
                        {
                            nameColor = item_Color.Color_Name;
                            break;
                        }
                    }
                    break;
                }
            }
            foreach (Categories item_Category in ListCategory)
            {
                if (item_Category.ID == item.Category_ID)
                {
                    category = item_Category.Category_name;
                    break;
                }
            }
            rowpag = rowpagDAL.updatePageSpl(count, item.ID, item.Name, nameSize, nameColor, item.Unit_price, category);
            rowPageSpls.Add(rowpag);
            count++;
        }

        return rowPageSpls;
    }

    // public Clothes GetSizeColorOfProduct(string ID)
    // {
    //     string query = @"select size_name, color_name from clothes inner join ";
    // }
    public Clothes GetProduct(MySqlDataReader reader)
    {
        Clothes clothes = new Clothes();
        clothes.ID = reader.GetInt32("Clothes_ID");
        clothes.Name = reader.GetString("Clothes_Name");
        clothes.Unit_price = reader.GetInt32("Unit_price");
        clothes.Material =reader.GetString("Material");
        clothes.Category_ID = reader.GetInt32("Category_ID");
        // clothes.user_manual = reader.GetString("User_manual");
        // clothes.status = reader.GetInt32("status");
        return clothes;
    }
}