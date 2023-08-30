using Persistence;
using DAL;

namespace BL
{
    public class StaffBL
    {
        private StaffDAL sDAL = new StaffDAL();
        public List<Staff> GetAllAccount()
        {
            return sDAL.GetAllAccount();
        }
    }
    
}