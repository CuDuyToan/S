using Persistence;
using DAL;

namespace BL
{
    public class SizeBL
    {
        SizeDAL sDAL = new SizeDAL();
        public List<Size> GetListSize()
        {
            return sDAL.GetListSize();
        }
    }
}