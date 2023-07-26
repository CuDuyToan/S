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
            Random random = new Random();
            query = @"select * from Customer where Phone_number=@phonenumber;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@phonenumber", phoneNum);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read()==true)
            {
                customer = GetUser(reader);
                reader.Close();
            }else{
                reader.Close();
                string query = @"INSERT INTO clothes_shop.customer (Phone_Number, Customer_Name) VALUES (@phonenumber, @namecustomer);";
                Console.Write("Not in the system please create new data.\nName customer: ");
                string nameCustomer = Console.ReadLine() ??"";
                Console.WriteLine("1");
                command = new MySqlCommand(query, connection);
                Console.WriteLine("2");
                command.Parameters.AddWithValue("@namecustomer", nameCustomer);
                Console.WriteLine("3");
                command.Parameters.AddWithValue("@phonenumber", phoneNum);
                Console.WriteLine("4");
                MySqlDataReader reader2 = command.ExecuteReader();
                Console.WriteLine("5");
                reader2.Close();
                
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
        customer.Name = reader.GetString("Customer_Name");
        return customer;
    }
}