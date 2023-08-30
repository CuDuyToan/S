using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        OrderDAL oDAL = new OrderDAL();
        public void InsertOrder(Order order, List<OrderDetails> ListOrderDetail)
        {
            oDAL.InsertOrder(order, ListOrderDetail);
        }

        public void updateDataMysql(List<Size_color> ListSzcl, List<OrderDetails> ListOrderDetail)
        {
            oDAL.updateDataMysql(ListSzcl, ListOrderDetail);
        }
        // public int GetTheLastOrderID()
        // {
        //     List<Order> orders = new List<Order>();
        //     orders = oDAL.GetOrders();
        //     return orders[orders.Count() - 1].OrderID;
        // }
        public Order createNewOrder(int staffID, string staffName, int status)
        {
            Order order = oDAL.createNewOrder(staffID, staffName, status);
            return order;
        }
    }
}
