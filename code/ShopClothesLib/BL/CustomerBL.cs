using Persistence;
using DAL;
using MySqlConnector;

namespace BL
{
    public class CustomerBL
    {
        private MySqlConnection connection = DbConfig.GetConnection();
        private CustomerDAL cDAL = new CustomerDAL();
        public string Authorize(string phoneNum)
        {
            Customer customer = new Customer();
            customer = cDAL.GetCustomerInfo(phoneNum);
            return phoneNum;
        }
    }
    
}