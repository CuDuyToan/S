using Persistence;
using DAL;
using MySqlConnector;

namespace BL
{
    public class CustomerBL
    {
        private MySqlConnection connection = DbConfig.GetConnection();
        private CustomerDAL cDAL = new CustomerDAL();
        public List<Customer> GetAllCustomer()
        {
            
            return cDAL.GetListCustomer();
        }
        public Customer UpCustomerToDB(string phoneNum, string nameCustomer, List<Customer> ListCustomer)
        {
            Customer customer = new Customer();
            customer = cDAL.UpCustomerToDB(phoneNum, nameCustomer);
            ListCustomer.Add(customer);
            return customer;
        }
    }
    
}