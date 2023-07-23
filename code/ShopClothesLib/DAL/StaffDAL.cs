using Persistence;
using MySqlConnector;
namespace DAL;

public class StaffDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public Staff GetUserAccount(string userName)
    {
        Staff staff = new Staff();
        try
        {
            query = @"select * from Staff where user_name=@username;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", userName);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                staff = GetUser(reader);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return staff;
    }
    public Staff GetUser(MySqlDataReader reader)
    {
        Staff staff = new Staff();
        staff.ID = reader.GetInt32("Staff_ID");
        staff.UserName = reader.GetString("user_name");
        staff.Password = reader.GetString("password");
        staff.PhoneNumber = reader.GetString("Phone_Number");
        staff.NameStaff = reader.GetString("Staff_Name");

        return staff;
    }
}