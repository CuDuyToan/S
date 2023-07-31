using Persistence;
using MySqlConnector;

namespace DAL;

public class ColorDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Color> GetListColor()
    {
        Color color = new Color();
        List<Color> ListColor = new List<Color>();
        try
        {
            query = @"SELECT * FROM clothes_shop.color;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                color = GetColor(reader);
                ListColor.Add(color);
            }
            reader.Close();

        }catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListColor;
    }
    public Color GetColor(MySqlDataReader reader)
    {
        Color color = new Color();
        color.Color_ID = reader.GetInt32("color_ID");
        color.Color_Name = reader.GetString("color_name");
        return color;
    }
}

