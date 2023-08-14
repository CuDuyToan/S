using BL;
using Persistence;
using DAL;
using CS;
using MySqlConnector;
using System;
using System.Text;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Ultilities CS = new Ultilities();
        Clothes clothes = new Clothes();
        Staff staff = new Staff(); 
        Customer customer = new Customer();
        Order order = new Order();

        ClothesDAL clDAL = new ClothesDAL();
        

        OrderBL oBL = new OrderBL();
        OrderDetailsBL ordDtlsBL = new OrderDetailsBL();
        CustomerBL cBL = new CustomerBL();
        ClothesBL clBL = new ClothesBL();
        StaffBL stBL = new StaffBL();
        ColorBL colBL = new ColorBL();
        SizeBL sBL = new SizeBL();
        SizeColorBL szclBL = new SizeColorBL();
        CategoryBL cgrBL = new CategoryBL();
        OrderDetails orderDetails;

        List<Clothes> ListClothes = new List<Clothes>();
        List<Color> ListColor = new List<Color>();
        List<Customer> ListCustomer = new List<Customer>();
        List<Size_color> ListSizeColor = new List<Size_color>();
        List<Size> ListSize = new List<Size>();
        List<Staff> listStaff = new List<Staff>();
        List<Categories> ListCategories = new List<Categories>();
        List<rowPageSpl> ListRowPage = new List<rowPageSpl>();
        List<Order> ListOrder = new List<Order>();
        List<OrderDetails> ListOrderDetail = new List<OrderDetails>();
        
        // string[] cashierMenu = { "Create Order.", "Confirm Order.", "Log Out." };
        string[] OrderMenu = { "Create New Order.", "Log Out." };
        // string[] loginMenu = { "Login.", "Exit." };
        string[] filterMenu = {"Show All.", "Show List Clothes By Category.", "Show Order", "Back Menu."};
        // string[] confirmOrderMenu = { "Show Order Detail.", "Confirm Order", "Cancel Order"};
        StaffBL uBL = new StaffBL();

        string conditionStr = "";
        string text, checkStr;
        bool checkTF = true, checkLogin = true;
        int status = 0, statusOrder = 0;
        string report = "";
        do
        {
            listStaff = stBL.GetAllAccount();
            int checkPass =0;
            Console.Clear();
            staff = CS.LoginMenu(listStaff);
            if (staff.Password == "" && staff.UserName == "")
            {
                return;
            }else
            {
                checkPass =1;
            }
            if (checkPass == 1)
            {
                string[] unprocessedAction = { "Change Status To Processing...", "Back To Previous Menu" };
                string[] processingAction = { "Change Status To Completed", "Back To Previous Menu" };
                string infoStaff = "[Staff: @" + staff.UserName + " | " + staff.NameStaff + " ]";
                bool active = true;
                
                while(active)
                {
                    ListClothes = clBL.GetAllProduct();
                    ListColor = colBL.GetListColor();
                    ListSize = sBL.GetListSize();
                    ListSizeColor = szclBL.GetSize_Colors();
                    ListCategories = cgrBL.GetCategories();
                    Console.Clear();
                    int orderChoice = CS.MenuHandle(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                                   ----Main Menu----                                                       |", OrderMenu, infoStaff);
                    if (orderChoice == 2)
                    {
                        break;
                    }else if(orderChoice == -1)
                    {
                        return;
                    }
                    switch (orderChoice)
                    {
                        case 1:
                            string phoneNum = "";
                            ListCustomer = cBL.GetAllCustomer();
                                order = new Order();
                                ListOrder = new List<Order>();
                                ListOrderDetail = new List<OrderDetails>();
                                status = 0;
                                statusOrder = 0;
                                Console.Clear();
                                customer = CS.enterPhoneCustomer(ListCustomer, infoStaff);
                                if (customer.Name == "")
                                {
                                    report = @"
                    [!] The customer is not in the database yet.
                     Pls enter customer name!";
                                    customer.Name = CS.newCustomer(infoStaff, customer.PhoneNumber, report);
                                    if (customer.Name != "TAB")
                                    {
                                        customer = cBL.UpCustomerToDB(customer.PhoneNumber, customer.Name, ListCustomer);
                                        ListCustomer = cBL.GetAllCustomer();
                                        foreach (Customer item in ListCustomer)
                                        {
                                            customer = item;
                                        }
                                    }else if (customer.Name == "TAB")
                                    {
                                        break;
                                    }
                                }
                                else if (customer.Name == "TAB")
                                {
                                    break;
                                }
                            order = oBL.createNewOrder(customer.ID, customer.PhoneNumber, staff.ID, staff.NameStaff, status);
                            int filterChoice = 1;
                            string infoCustomer = "[Customer : <phone> " + customer.PhoneNumber + " | <name> " + customer.Name + " ]";
                            if(phoneNum != "EXIT")
                            {
                                while(filterChoice != 0)
                                {
                                    filterChoice = 0;
                                    Console.Clear();
                                    filterChoice = CS.MenuHandle(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                            ----Create order menu----                                                      |", filterMenu, infoStaff, infoCustomer);
                                    if (filterChoice == -1)
                                    {
                                        return;
                                    }
                                    switch (filterChoice)
                                    {
                                        case 1:
                                            checkTF = true;
                                            text = @"
                    [?] Are you sure you want to show all the clothes?";
                                            checkStr = CS.pressEnterTab(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                            ----Create order menu----                                                      |", filterMenu, filterChoice, infoStaff, infoCustomer, text);
                                            if (checkStr == "ESCAPE")
                                            {
                                                return;
                                            }else if (checkStr == "TAB")
                                            {
                                                break;
                                            }
                                            int ID = 1;
                                            while(checkTF && ID >0)
                                            {
                                                conditionStr = "";
                                                string title = @"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                              ----List clothes----                                                         |";
                                                ID = CS.PageSplit(ListRowPage, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, title, infoStaff, infoCustomer, conditionStr);
                                                string quantity;
                                                if (ID > 0)
                                                {
                                                    quantity = CS.showInfoClothes(ID, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                                    orderDetails = new OrderDetails();
                                                    if(quantity == "ESCAPE")
                                                    {
                                                        return;
                                                    }else if (quantity == "TAB")
                                                    {
                                                    }else
                                                    {
                                                        statusOrder = 1;
                                                        int quantityOrder = Convert.ToInt32(quantity);
                                                        int Unit_price=0;
                                                        foreach (Clothes item in ListClothes)
                                                        {
                                                            if(item.ID == ID)
                                                            {
                                                                Unit_price=item.Unit_price;
                                                                break;
                                                            }
                                                        }
                                                        foreach (Size_color item_SizeColor in ListSizeColor)
                                                        {
                                                            if (item_SizeColor.clothes_ID == ID)
                                                            {
                                                                item_SizeColor.Quantity -= quantityOrder;
                                                                break;
                                                            }
                                                        }
                                                        order.TotalPrice += Unit_price*quantityOrder;
                                                        int checkQuantity=0;
                                                        foreach (OrderDetails item in ListOrderDetail)
                                                        {
                                                            if (item.ClothesID == ID)
                                                            {
                                                                item.Quantity += quantityOrder;
                                                                checkQuantity =1;
                                                                break;
                                                            }
                                                        }
                                                        if (checkQuantity==0)
                                                        {
                                                            orderDetails  = ordDtlsBL.addClothesToOrder(order.OrderID, ID, Unit_price, quantityOrder);
                                                            ListOrderDetail.Add(orderDetails);
                                                        }
                                                    }
                                                }else if(ID == 0)
                                                {
                                                    checkTF = false;
                                                    break;
                                                }else if (ID == -1)
                                                {
                                                    return;
                                                }
                                            }
                                            break;
                                        case 2:
                                            text = @"
                    [?] Are you sure you want to list clothes by category?";
                                            checkStr = CS.pressEnterTab(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                            ----Create order menu----                                                      |", filterMenu, filterChoice, infoStaff, infoCustomer, text);
                                            int CategoryID;
                                            conditionStr = "";
                                            if (checkStr == "ESCAPE")
                                            {
                                                return;
                                            }else if (checkStr == "TAB")
                                            {
                                                break;
                                            }
                                            checkTF=true;
                                            CategoryID = CS.choiceCategory(ListCategories, infoStaff, infoCustomer);
                                            if (CategoryID == -1)
                                            {
                                                return;
                                            }else if (CategoryID == 0)
                                            {
                                                break;
                                            }
                                            foreach (Categories item in ListCategories)
                                            {
                                                if (item.ID == CategoryID)
                                                {
                                                    conditionStr = item.Category_name;
                                                    break;
                                                }
                                            }
                                            ID = 1;
                                            while (checkTF && ID > 0)
                                            {
                                                string title = @"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                          ----List clothes by category----                                                 |";
                                                ID = CS.PageSplit(ListRowPage, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, title, infoStaff, infoCustomer, conditionStr);
                                                if(ID == 0)
                                                {
                                                    break;
                                                }
                                                string quantity;
                                                bool checkList = true;
                                                while (checkList && ID > 0)
                                                {
                                                    if (ID != 0)
                                                    {
                                                        quantity = CS.showInfoClothes(ID, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                                        checkList = false;
                                                        orderDetails = new OrderDetails();
                                                        if (quantity == "Create Order Menu")
                                                        {
                                                            checkList = false;
                                                        }else if (quantity == "TAB")
                                                        {
                                                            
                                                            break;
                                                        }else
                                                        { 
                                                            statusOrder = 1;
                                                            int quantityOrder = Convert.ToInt32(quantity);
                                                            int Unit_price=0;
                                                            foreach (Clothes item in ListClothes)
                                                            {
                                                                if(item.ID == ID)
                                                                {
                                                                    Unit_price=item.Unit_price;
                                                                    break;
                                                                }
                                                            }
                                                            foreach (Size_color item_SizeColor in ListSizeColor)
                                                            {
                                                                if (item_SizeColor.clothes_ID == ID)
                                                                {
                                                                    item_SizeColor.Quantity -= quantityOrder;
                                                                    break;
                                                                }
                                                            }
                                                            order.TotalPrice += Unit_price*quantityOrder;
                                                            int checkQuantity=0;
                                                            foreach (OrderDetails item in ListOrderDetail)
                                                            {
                                                                if (item.ClothesID == ID)
                                                                {
                                                                    item.Quantity += quantityOrder;
                                                                    checkQuantity =1;
                                                                    break;
                                                                }
                                                            }
                                                            if (checkQuantity==0)
                                                            {
                                                                orderDetails  = ordDtlsBL.addClothesToOrder(order.OrderID, ID, Unit_price, quantityOrder);
                                                                ListOrderDetail.Add(orderDetails);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 3:
                                        statusOrder =0;
                                        foreach (OrderDetails item in ListOrderDetail)
                                        {
                                            if (item.Quantity > 1)
                                            {
                                                statusOrder = 1;
                                                break;
                                            }
                                        }
                                            List<OrderDetails> checkOrderdetail = new List<OrderDetails>();
                                            text = @"
                    [?] Show Order?";
                                            checkStr = CS.pressEnterTab(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                           ----Create order menu----                                                       |", filterMenu, filterChoice, infoStaff, infoCustomer, text);
                                            if (statusOrder == 0 && checkStr == "ENTER")
                                            {
                                                do
                                                {
                                                    text = @"
                    [!] There are no clothes in the order.
                    {Enter} to continnue.";
                                                    checkStr = CS.pressEnterTab(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                           ----Create order menu----                                                       |", filterMenu, filterChoice, infoStaff, infoCustomer, text);
                                                } while (checkStr != "ENTER");
                                                break;
                                            }
                                            else if (statusOrder == 1 && checkStr != "TAB")
                                            {
                                                checkOrderdetail = CS.ShowOrderDetails(order, ListOrderDetail, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, customer.Name, customer.PhoneNumber, staff.NameStaff);
                                                if (checkOrderdetail == null)
                                                {
                                                    break;
                                                }else if (checkOrderdetail.Count() == 0)
                                                {
                                                    filterChoice = 4;
                                                }
                                                else
                                                {
                                                    statusOrder =0;
                                                    foreach (OrderDetails item in ListOrderDetail)
                                                    {
                                                        if (item.Quantity > 0)
                                                        {
                                                            statusOrder = 1;
                                                            break;
                                                        }
                                                    }
                                                    if (statusOrder == 0)
                                                    {
                                                        do
                                                        {
                                                            text = @"
                    [!] There are no clothes in the order.
                    {Enter} to continnue.";
                                                            checkStr = CS.pressEnterTab(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                           ----Create order menu----                                                       |", filterMenu, filterChoice, infoStaff, infoCustomer, text);
                                                        } while (checkStr != "ENTER");
                                                        break;
                                                    }else
                                                    {
                                                        oBL.InsertOrder(order, ListOrderDetail);
                                                        oBL.updateDataMysql(ListSizeColor, ListOrderDetail);
                                                        filterChoice = 4;
                                                    }
                                                }
                                            }else if (checkStr == "ESCAPE")
                                            {
                                                return;
                                            }else if (checkStr == "TAB")
                                            {
                                                break;
                                            }
                                            break;
                                        case 4:
                                            
                                            text = @"
                    [?] Back to Main Menu?";
                                            checkStr = CS.pressEnterTab(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                           ----Create order menu----                                                       |", filterMenu, filterChoice, infoStaff, infoCustomer, text);
                                            if (checkStr == "ENTER")
                                            {
                                                filterChoice = 0;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            break;
                        case 2:
                            active = false;
                            break;
                        default:
                            break;
                    }
                }
            }

        } while (checkLogin);
    }
}
