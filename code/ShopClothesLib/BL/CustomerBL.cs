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
        public string newCustomer(string phoneNum)
        {
            Customer customer = new Customer();
            customer = cDAL.newCustomer(phoneNum);
            return phoneNum;
        }
    }
    
}