using Persistence;
using MySqlConnector;
namespace DAL;

public class StaffDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();

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