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
    public Clothes GetProductByID(int productID)
    {
        Clothes product = new Clothes();
        try
        {
            query = @"select * from Clothes_Shop.clothes WHERE Clothes_ID = @clothesid;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@clothesid", productID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
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
    public Clothes GetProduct(MySqlDataReader reader)
    {
        Clothes clothes = new Clothes();
        clothes.ID = reader.GetInt32("Clothes_ID");
        clothes.Size_ID = reader.GetString("Size");
        clothes.Name = reader.GetString("Clothes_Name");
        clothes.Quantity = reader.GetInt32("Quantity");
        clothes.Color_ID = reader.GetString("Color");
        clothes.Price = reader.GetInt32("Unit_price");
        clothes.Material =reader.GetString("Material");
        clothes.Category = reader.GetString("Category");
        return clothes;
    }
}