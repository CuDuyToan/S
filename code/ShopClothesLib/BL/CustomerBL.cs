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
        public Customer newCustomer(string phoneNum, List<Customer> ListCustomer)
        {
            Customer customer = new Customer();
            customer = cDAL.newCustomer(phoneNum);
            ListCustomer.Add(customer);
            return customer;
        }
    }
    
}