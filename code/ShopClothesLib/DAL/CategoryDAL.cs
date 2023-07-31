using Persistence;
using MySqlConnector;

namespace DAL;

public class CategoryDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Categories> GetListCategories()
    {
        Categories color = new Categories();
        List<Categories> ListColor = new List<Categories>();
        try
        {
            query = @"SELECT * FROM clothes_shop.categories;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                color = GetCategory(reader);
                ListColor.Add(color);
            }
            reader.Close();

        }catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListColor;
    }
    public Categories GetCategory(MySqlDataReader reader)
    {
        Categories categories = new Categories();
        categories.ID = reader.GetInt32("category_ID");
        categories.Category_name = reader.GetString("category_name");
        return categories;
    }
}

