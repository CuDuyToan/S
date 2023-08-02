using Persistence;
using MySqlConnector;

namespace DAL;

public class CategoryDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Categories> GetListCategories()
    {
        Categories categories = new Categories();
        List<Categories> ListCategories = new List<Categories>();
        try
        {
            query = @"SELECT * FROM clothes_shop.categories;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories = GetCategory(reader);
                ListCategories.Add(categories);
            }
            reader.Close();

        }catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListCategories;
    }
    public Categories GetCategory(MySqlDataReader reader)
    {
        Categories categories = new Categories();
        categories.ID = reader.GetInt32("category_ID");
        categories.Category_name = reader.GetString("category_name");
        return categories;
    }
}

