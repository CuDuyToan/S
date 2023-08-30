using Persistence;
using DAL;

namespace BL
{
    public class OrderDetailsBL
    {
        OrderDetailsDAL ordDtlsDAL = new OrderDetailsDAL();

        public OrderDetails addClothesToOrder(int orderID, int clothesID, int unitPrice, int Quantity)
        {
            return ordDtlsDAL.AddClothesToOrder(orderID, clothesID, unitPrice, Quantity);
        }
    }
}