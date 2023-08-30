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