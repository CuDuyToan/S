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
        public decimal CalculateTotalPriceInOrder(List<OrderDetails> orderDetails, List<Clothes> clothes )
        {
            ClothesBL cBL = new ClothesBL();
            decimal sum = 0;
            decimal rowPrice;
            string nameClothes = "";
            foreach (OrderDetails item in orderDetails)
            {
                foreach(Clothes item_clothes in clothes)
                {
                    if (item_clothes.ID == item.ClothesID)
                    {
                        nameClothes = item_clothes.Name;
                    }
                }
                rowPrice = item.Quantity * cBL.GetPriceByProductName(nameClothes);
                sum += rowPrice;
            }
            return sum;
        }
        public Order createNewOrder(int customerID, string customerPhone, int staffID, string staffName, int status)
        {
            Order order = oDAL.createNewOrder(customerID, customerPhone, staffID, staffName, status);
            return order;
        }
    }
}
