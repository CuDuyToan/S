using Persistence;
using MySqlConnector;
using System.Text;
namespace DAL;

public class CustomerDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public List<Customer> GetListCustomer()
    {
        Customer customer = new Customer();
        List<Customer> ListCustomer = new List<Customer>();
        try
        {
            query = @"SELECT * FROM clothes_shop.customer;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customer = GetCustomer(reader);
                ListCustomer.Add(customer);
            }
            reader.Close();

        }catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return ListCustomer;
    }
    public Customer UpCustomerToDB(string phoneNum, string nameCustomer)
    {
        Customer customer = new Customer();
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        try
        {
            query = @"INSERT INTO clothes_shop.customer (Phone_Number, Customer_Name) VALUES (@phonenumber, @namecustomer);";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.Write("Not in the system please create new data.\nName customer: ");
            Console.WriteLine(nameCustomer);
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@namecustomer", nameCustomer);
            command.Parameters.AddWithValue("@phonenumber", phoneNum);
            MySqlDataReader reader2 = command.ExecuteReader();
            reader2.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return customer;
    }
    public Customer GetCustomer(MySqlDataReader reader)
    {
        Customer customer = new Customer();
        customer.ID = reader.GetInt32("Customer_ID");
        customer.PhoneNumber = reader.GetString("Phone_Number");
        customer.Name = reader.GetString("Customer_Name");
        return customer;
    }
}