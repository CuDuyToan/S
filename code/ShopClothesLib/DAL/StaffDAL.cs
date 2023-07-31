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
            query = @"select * from clothes_shop.staffs where user_name=@username;";
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

        public List<Staff> GetAllAccount()
    {
        Staff staff = new Staff();
        List<Staff> ListStaff = new List<Staff>();
        try
        {
            query = @"SELECT * FROM clothes_shop.staffs;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                staff = GetUser(reader);
                ListStaff.Add(staff);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListStaff;
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