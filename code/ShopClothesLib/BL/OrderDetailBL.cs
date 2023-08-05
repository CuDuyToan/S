using Persistence;
using DAL;

namespace BL
{
    public class OrderDetailsBL
    {
        OrderDetailsDAL ordDtlsDAL = new OrderDetailsDAL();
        public List<OrderDetails> GetOrderDetailsByID(int ID){
            return ordDtlsDAL.GetOrderDetailsByID(ID);
        }

        public bool AddListProductToOrder(List<OrderDetails> orderDetails) {
            return ordDtlsDAL.InsertOrderDetails(orderDetails);
        }

        public OrderDetails addClothesToOrder(int orderID, int clothesID, int unitPrice, int Quantity)
        {
            return ordDtlsDAL.AddClothesToOrder(orderID, clothesID, unitPrice, Quantity);
        }
    }
}