using Persistence;
using DAL;

namespace BL
{
    public class StaffBL
    {
        private StaffDAL sDAL = new StaffDAL();
        public int Authorize(string userName, string password)
        {
            Staff staff = new Staff();
            staff = sDAL.GetUserAccount(userName);
            if (staff.Password == password)
            {
                return 1;
            }
            return -1;
        }
        public int GetUserIDByUserName(string userName)
        {
            Staff staff = new Staff();
            staff = sDAL.GetUserAccount(userName);
            return staff.ID;
        }
    }
    
}