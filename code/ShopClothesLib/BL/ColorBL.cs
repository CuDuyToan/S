using Persistence;
using DAL;

namespace BL
{
    public class ColorBL
    {
        ColorDAL cDAL = new ColorDAL();
        public List<Color> GetListColor()
        {
            return cDAL.GetListColor();
        }
    }
}