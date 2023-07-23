using Persistence;
using MySqlConnector;
namespace DAL;

public class CustomerDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public Customer GetCustomerInfo(string phoneNum)
    {
        Customer customer = new Customer();
        try
        {
            int randomID;
            Random random = new Random();
            query = @"select * from Customer where Phone_number=@phonenumber;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@phonenumber", phoneNum);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                customer = GetUser(reader);
            }else{
                for(int i = 0; i<1; i++)
                {
                    randomID = random.Next(9999);
                    query = @"select Customer_ID from Customer where Customer_ID=@customerid;";
                    MySqlCommand command2 = new MySqlCommand(query, connection);
                    command2.Parameters.AddWithValue("@customerid", randomID);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                    {
                        i--;
                    }else{
                        query = @"INSERT INTO clothing_shop.customers (Customer_ID, Phone_number, Name) VALUES (@customerid, @phonenumber, @namecustomer);";
                        Console.WriteLine("Not in the system please create new data");
                        string nameCustomer = Console.ReadLine();
                        MySqlCommand command3 = new MySqlCommand(query, connection);
                        command3.Parameters.AddWithValue("@customerid", randomID);
                        command3.Parameters.AddWithValue("@namecustomer", nameCustomer);
                        command3.Parameters.AddWithValue("@phonenumber", phoneNum);
                        MySqlDataReader reader3 = command2.ExecuteReader();
                        reader3.Close();
                    }
                    reader2.Close();
                }
                reader.Close();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return customer;
    }
    public Customer GetUser(MySqlDataReader reader)
    {
        Customer customer = new Customer();
        customer.ID = reader.GetInt32("Customer_ID");
        customer.PhoneNumber = reader.GetString("Phone_number");
        customer.Name = reader.GetString("Name");
        return customer;
    }
}