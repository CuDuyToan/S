using Persistence;
using MySqlConnector;

namespace DAL;

public class SizeDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Size> GetListSize()
    {
        Size Size = new Size();
        List<Size> ListSize = new List<Size>();
        try
        {
            query = @"SELECT * FROM clothes_shop.size;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Size = GetSize(reader);
                ListSize.Add(Size);
            }
            reader.Close();

        }catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListSize;
    }
    public Size GetSize(MySqlDataReader reader)
    {
        Size Size = new Size();
        Size.Size_ID = reader.GetInt32("size_ID");
        Size.Size_Name = reader.GetString("size_name");
        return Size;
    }
}

