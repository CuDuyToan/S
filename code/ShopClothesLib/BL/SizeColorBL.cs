using Persistence;
using DAL;

namespace BL
{
    public class SizeColorBL
    {
        SizeColorDAL szclDAL = new SizeColorDAL();
        public List<Size_color> GetSize_Colors()
        {
            return szclDAL.GetSize_Colors();
        }
    }
}