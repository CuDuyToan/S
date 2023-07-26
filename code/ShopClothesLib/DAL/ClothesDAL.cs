using Persistence;
using MySqlConnector;
namespace DAL;

public class ClothesDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Clothes> GetProducts()
    {
        Clothes product = new Clothes();
        List<Clothes> products = new List<Clothes>();
        try
        {
            query = @"select * from Clothes_Shop.clothes;";
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
    public List<Clothes> GetProductsByCategory(string category)
    {
        Clothes product = new Clothes();
        List<Clothes> products = new List<Clothes>();
        try
        {
            query = @"select  clothes.Clothes_ID, clothes.Clothes_Name, clothes.Unit_price,  clothes.Material, categories.category_name from clothes_shop.clothes inner join clothes_shop.categories on clothes.Category_ID = categories.category_ID where categories.category_name = @category;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@category", category);
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

    public Clothes GetProductByID(string ID)
    {
        Clothes product = new Clothes();
        try
        {
            query = @"select  clothes.Clothes_ID, clothes.Clothes_Name, clothes.Unit_price,  clothes.Material, categories.category_name from clothes_shop.clothes inner join clothes_shop.categories on clothes.Category_ID = categories.category_ID where clothes.clothes_ID = @ID;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                product = GetProduct(reader);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return product;
    }

    // public Clothes GetSizeColorOfProduct(string ID)
    // {
    //     string query = @"select size_name, color_name from clothes inner join ";
    // }
    public Clothes GetProduct(MySqlDataReader reader)
    {
        Clothes clothes = new Clothes();
        clothes.ID = reader.GetInt32("Clothes_ID");
        // clothes.Size = reader.GetString("Size");
        clothes.Name = reader.GetString("Clothes_Name");
        // clothes.Quantity = reader.GetInt32("Quantity");
        // clothes.Color = reader.GetString("Color");
        clothes.Price = reader.GetInt32("Unit_price");
        clothes.Material =reader.GetString("Material");
        clothes.Category = reader.GetString("category_name");
        return clothes;
    }
}