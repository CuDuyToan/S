using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        OrderDAL oDAL = new OrderDAL();
        public bool GetOrderCreator(int customerID, int orderID)
        {
            Order order = new Order();
            order.OrderID = orderID;
            order.CustomerID = customerID;
            return oDAL.InsertOrder(order);
        }
        public int GetTheLastOrderID()
        {
            List<Order> orders = new List<Order>();
            orders = oDAL.GetOrders();
            return orders[orders.Count() - 1].OrderID;
        }
        public decimal CalculateTotalPriceInOrder(List<OrderDetails> orderDetails)
        {
            ClothesBL cBL = new ClothesBL();
            decimal sum = 0;
            decimal rowPrice;
            foreach (OrderDetails item in orderDetails)
            {
                rowPrice = item.Quantity * cBL.GetPriceByProductName(item.ClothesID);
                sum += rowPrice;
            }
            return sum;
        }
    }
}
