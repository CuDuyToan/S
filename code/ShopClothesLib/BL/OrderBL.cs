using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        OrderDAL oDAL = new OrderDAL();
        // public bool GetOrderCreator(int customerID, int orderID)
        // {
        //     Order order = new Order();
        //     order.OrderID = orderID;
        //     order.CustomerID = customerID;
        //     return oDAL.InsertOrder(order);
        // }
        public void InsertOrder(Order order, List<OrderDetails> ListOrderDetail)
        {
            oDAL.InsertOrder(order, ListOrderDetail);
        }

        // public List<OrderDetails> showOrderDetail(Order order, List<OrderDetails> ListOrderDetail, List<Clothes> listClothes, List<Size_color> listSzcl, List<Size> listSize, List<Color> listColor,List<Categories> listCategory, string CustomerName, string CustomerPhone, string NameStaff)
        // {
        //     return oDAL.ShowOrderDetails(order, ListOrderDetail, listClothes, listSzcl, listSize, listColor, listCategory, CustomerName, CustomerPhone, NameStaff);
        // }

        // public List<OrderDetails> updateOrderDetail(List<OrderDetails> ListOrderDetail)
        // {
        //     List<OrderDetails> listUpdateOrderdetail = new List<OrderDetails>();
        //     return listUpdateOrderdetail;
        // }

        // public void ViewOrderDetail()
        // {
        //     oDAL
        // }

        public void updateDataMysql(List<Size_color> ListSzcl, List<OrderDetails> ListOrderDetail)
        {
            oDAL.updateDataMysql(ListSzcl, ListOrderDetail);
        }
        public int GetTheLastOrderID()
        {
            List<Order> orders = new List<Order>();
            orders = oDAL.GetOrders();
            return orders[orders.Count() - 1].OrderID;
        }
        // public decimal CalculateTotalPriceInOrder(List<OrderDetails> orderDetails, List<Clothes> clothes )
        // {
        //     ClothesBL cBL = new ClothesBL();
        //     decimal sum = 0;
        //     decimal rowPrice;
        //     string nameClothes = "";
        //     foreach (OrderDetails item in orderDetails)
        //     {
        //         foreach(Clothes item_clothes in clothes)
        //         {
        //             if (item_clothes.ID == item.ClothesID)
        //             {
        //                 nameClothes = item_clothes.Name;
        //             }
        //         }
        //         rowPrice = item.Quantity * cBL.GetPriceByProductName(nameClothes);
        //         sum += rowPrice;
        //     }
        //     return sum;
        // }
        public Order createNewOrder(int staffID, string staffName, int status)
        {
            Order order = oDAL.createNewOrder(staffID, staffName, status);
            return order;
        }
    }
}
