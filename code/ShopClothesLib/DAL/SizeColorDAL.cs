using Persistence;
using MySqlConnector;

namespace DAL;

public class SizeColorDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Size_color> GetSize_Colors()
    {
        Size_color Size = new Size_color();
        List<Size_color> ListSize = new List<Size_color>();
        try
        {
            query = @"SELECT * FROM clothes_shop.size_color;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Size = GetSizeColor(reader);
                ListSize.Add(Size);
            }
            reader.Close();

        }catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListSize;
    }
    public Size_color GetSizeColor(MySqlDataReader reader)
    {
        Size_color szcl = new Size_color();
        szcl.size_color_ID = reader.GetInt32("size_color_ID");
        szcl.clothes_ID = reader.GetInt32("clothes_ID"); 
        szcl.Size_ID = reader.GetInt32("size_ID");
        szcl.Color_ID = reader.GetInt32("color_ID");
        szcl.Quantity = reader.GetInt32("quantity");
        return szcl;
    }
}

