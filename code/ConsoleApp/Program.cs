﻿using BL;
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
        
        string[] cashierMenu = { "Create Order.", "Confirm Order.", "Log Out." };
        string[] OrderMenu = { "Create New Order.", "Log Out." };
        string[] loginMenu = { "Login.", "Exit." };
        string[] filterMenu = {"Show All.", "Show List Clothes By Category.", "Show Order", "Back Menu."};
        string[] confirmOrderMenu = { "Show Order Detail.", "Confirm Order", "Cancel Order"};
        StaffBL uBL = new StaffBL();

        // ListClothes = clBL.GetAllProduct();
        // listStaff = stBL.GetAllAccount();
        // ListColor = colBL.GetListColor();
        // ListSize = sBL.GetListSize();
        // ListSizeColor = szclBL.GetSize_Colors();
        // ListCategories = cgrBL.GetCategories();

        ConsoleKeyInfo checkKey;
        int Count =0;
        string conditionStr = "";
        string text, checkStr;
        bool checkTF = true, checkLogin = true;
        string username = "", pwd="";
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
//             CS.Title(@"
//                                     ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐    
//                                     ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘    
//                                     ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴  
//                     ");
//             Console.WriteLine("[Esc] to back and exit.");
//             Console.WriteLine("[Backspace] to delete text.");
//             Console.WriteLine("[Enter] to complete text.");
//             if (Count == 1)Console.WriteLine("[!]Username or password incorrect.");
//             Console.Write(" UserName: ");
//             if (Count ==0)
//             {
//                 username = CS.enterString();
//                 Count =1;
//             }else{
//                 Console.WriteLine(username);
//             }
//             if(username == "EXIT")
//             {
//                 Console.WriteLine("\nExiting...");
//                 break;
//             }else if(username == "RE-ENTER")
//             {
//                 Count = 0;
//             }else if (username != "EXIT" && username != "RE-ENTER")
//             {
//                 Console.Write(" Password: ");
//                 pwd = CS.hidePassword();
//                 Count = 1;
// //<><><><><><><><><><><><><><><><><><><><><><><><>
//                 // given, a password in a string
//                 string password = pwd;

//                 // byte array representation of that string
//                 byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

//                 // need MD5 to calculate the hash
//                 byte[] hash = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

//                 // string representation (similar to UNIX format)
//                 string encoded = BitConverter.ToString(hash)
//                 // without dashes
//                 .Replace("-", string.Empty)
//                 // make lowercase
//                 .ToLower();

//                 // encoded contains the hash you want
// //<><><><><><><><><><><><><><><><><><><><><><><><>
//                 if(pwd == "EXIT")
//                 {
//                     Count =0;
//                 }else if(pwd != "RE-ENTER" && pwd != "EXIT")
//                 {
//                     foreach (Staff item in listStaff)
//                     {
//                         if (item.UserName == username && item.Password == encoded)
//                         {
//                             checkPass = 1;
//                             staff = item;
//                         }
//                     }
//                 }else
//                 {
//                     Count =2;
//                 }
//             }
            // int checkPass = uBL.Authorize(username, pwd);
            if (checkPass == 1)
            {
                string[] unprocessedAction = { "Change Status To Processing...", "Back To Previous Menu" };
                string[] processingAction = { "Change Status To Completed", "Back To Previous Menu" };
                // int ordID;
                string infoStaff = "[Staff: @" + staff.UserName + " | " + staff.NameStaff + " ]";
                // int clID;
                bool active = true;
                // bool activeSub = true, activeSub2 = true;
                
                while(active)
                {
                    bool activeNum = true, activeNum2 = true;
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
                        // tao mot order moi
                        case 1:
                            string phoneNum = "";
                            ListCustomer = cBL.GetAllCustomer();
                            int checkCustomer = 0;
                            // while (activeNum)
                            // {
                                order = new Order();
                                ListOrder = new List<Order>();
                                ListOrderDetail = new List<OrderDetails>();
                                status = 0;
                                statusOrder = 0;
                                
                                // ListOrder.Add(order);
                                Console.Clear();
                                customer = CS.enterPhoneCustomer(ListCustomer, infoStaff);
                                if (customer.Name == "")
                                {
                                    report = @"
                    [!] The customer is not in the database yet.
                     Pls enter customer name!";
                                    customer.Name = CS.newCustomer(infoStaff, customer.PhoneNumber, report);
                                    // customer.Name = CS.enterString();
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
                                    // else if (customer.Name == "EXIT")
                                    // {
                                    //     return;
                                    // }
                                    checkCustomer = 1;
                                    activeNum = false;
                                }
                                // else if (customer.Name == "EXIT")
                                // {
                                //     return;
                                // }
                                else if (customer.Name == "TAB")
                                {
                                    break;
                                }
                    //             Console.Write(@"
                    // =============================================================================================================================
                    // |                                                                                                                           |
                    // |                                       ╔═╗┬─┐┌─┐┌─┐┌┬┐┌─┐  ┌┐┌┌─┐┬ ┬  ┌─┐┬─┐┌┬┐┌─┐┬─┐                                      |
                    // |                                       ║  ├┬┘├┤ ├─┤ │ ├┤   │││├┤ │││  │ │├┬┘ ││├┤ ├┬┘                                      |
                    // |                                       ╚═╝┴└─└─┘┴ ┴ ┴ └─┘  ┘└┘└─┘└┴┘  └─┘┴└──┴┘└─┘┴└─                                      |
                    // |                                                                                                                           |
                    // =============================================================================================================================");
                    //             Console.Write("Phone number: ");
                    //             phoneNum = CS.enterPhone();
                    //             if (phoneNum != "RE-ENTER" && phoneNum != "EXIT")
                    //             {
                    //                 if (phoneNum.Length==10)
                    //                 {
                    //                     activeNum2=true;
                    //                     checkCustomer = 0;
                    //                     while (activeNum2)
                    //                     {
                    //                         Console.Clear();
                    //                         if (checkCustomer == 0)
                    //                         {
                    //                             Console.WriteLine("\nUse phone number [{0}].\n[Enter] key to continue.\n[Backspace] to re-enter the phone number.\n[Esc] to back Order Choice.", phoneNum);
                    //                         }else if(checkCustomer == 1)
                    //                         {
                    //                             Console.WriteLine("successfully added new customers.\n[Enter] to continue");
                    //                         }
                    //                         checkKey = Console.ReadKey(true);
                    //                         if (checkKey.Key == ConsoleKey.Enter)
                    //                         {
                    //                             foreach (Customer item in ListCustomer)
                    //                             {
                    //                                 if(item.PhoneNumber == phoneNum){
                    //                                     customer=item;
                    //                                     checkCustomer =1;
                    //                                     activeNum = false;
                    //                                     activeNum2 = false;
                    //                                 }
                    //                             }
                    //                             if (checkCustomer == 0)
                    //                             {
                    //                                 Console.Write("The customer is not in the database yet.\nEnter Name Customer: ");
                    //                                 string nameCustomer = CS.enterString();
                    //                                 if (nameCustomer != "EXIT")
                    //                                 {
                    //                                     customer = cBL.newCustomer(phoneNum, nameCustomer, ListCustomer);
                    //                                     ListCustomer = cBL.GetAllCustomer();
                    //                                 }
                    //                                 checkCustomer = 1;
                    //                                 activeNum = false;
                    //                                 // activeNum2 = false;
                    //                             }
                    //                         }else if (checkKey.Key == ConsoleKey.Escape)
                    //                         {
                    //                             activeNum = false;
                    //                             activeNum2 = false;
                    //                             phoneNum = "EXIT";
                    //                         }else if (checkKey.Key == ConsoleKey.Backspace)
                    //                         {
                    //                             activeNum2 = false;
                    //                         }
                    //                     }
                    //                 }
                    //             }else if(phoneNum == "EXIT")
                    //             {
                    //                 break;
                    //             }
                            // }
                            order = oBL.createNewOrder(customer.ID, customer.PhoneNumber, staff.ID, staff.NameStaff, status);
                            int filterChoice = 0;
                            string infoCustomer = "[Customer : <phone> " + customer.PhoneNumber + " | <name> " + customer.Name + " ]";
                            if(phoneNum != "EXIT")
                            {
                                while(filterChoice != 4)
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
                                                //*
                                                string quantity;
                                                if (ID > 0)
                                                {
                                                    quantity = CS.showInfoClothes(ID, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                                    orderDetails = new OrderDetails();
                                                    // text = "Enter quantity: ";
                                                    // string quantity = CS.OnlyEnterNumber(text);
                                                    if(quantity == "ESCAPE")
                                                    {
                                                        return;
                                                    }else if (quantity == "TAB")
                                                    {
                                                        // break;
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
                                                        // Console.WriteLine("Add {0} to order.\n press [Enter] key to confirm or [Esc] back to list clothes.", clothesName);
                                                        // bool checkTFInfoCL = true;
                                                        // while(checkTFInfoCL)
                                                        // {
                                                        //     checkKey = Console.ReadKey(true);
                                                        //     if(checkKey.Key == ConsoleKey.Escape)
                                                        //     {
                                                        //         checkTFInfoCL = false;
                                                        //     }else if(checkKey.Key == ConsoleKey.Enter)
                                                        //     {
                                                        //         orderDetails = new OrderDetails();
                                                        //         statusOrder = 1;
                                                        //         text = "Enter quantity: ";
                                                        //         // string quantity = CS.OnlyEnterNumber(text);
                                                        //         if (quantity == "EXIT")
                                                        //         {
                                                        //             break;
                                                        //         }
                                                        //         int quantityOrder = Convert.ToInt32(quantity);
                                                        //         int Unit_price=0;
                                                        //         foreach (Clothes item in ListClothes)
                                                        //         {
                                                        //             if(item.ID == ID)
                                                        //             {
                                                        //                 Unit_price=item.Unit_price;
                                                        //                 break;
                                                        //             }
                                                        //         }
                                                        //         foreach (Size_color item_SizeColor in ListSizeColor)
                                                        //         {
                                                        //             if (item_SizeColor.clothes_ID == ID)
                                                        //             {
                                                        //                 item_SizeColor.Quantity -= quantityOrder;
                                                        //                 break;
                                                        //             }
                                                        //         }
                                                        //         order.TotalPrice += Unit_price*quantityOrder;
                                                        //         int checkQuantity=0;
                                                        //         foreach (OrderDetails item in ListOrderDetail)
                                                        //         {
                                                        //             if (item.ClothesID == ID)
                                                        //             {
                                                        //                 item.Quantity += quantityOrder;
                                                        //                 checkQuantity =1;
                                                        //                 break;
                                                        //             }
                                                        //         }
                                                        //         if (checkQuantity==0)
                                                        //         {
                                                        //             orderDetails  = ordDtlsBL.addClothesToOrder(order.OrderID, ID, Unit_price, quantityOrder);
                                                        //             ListOrderDetail.Add(orderDetails);
                                                        //         }
                                                        //         checkTFInfoCL = false;
                                                        //     }
                                                        // }
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
                                            string str ="";
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
                                            // while (checkTF)
                                            // {

                                            //     int count = 1;
                                            //     CS.Line();
                                            //     Console.Clear();
                                            //     Console.Write(str);
                                            //     foreach (Categories item in ListCategories)
                                            //     {
                                            //         Console.WriteLine("{0}. {1}.", count, item.Category_name);
                                            //         count++;
                                            //     }
                                            //     CS.Line();
                                            //     Console.Write("Enter Category: ");
                                            //     foreach (Categories item in ListCategories)
                                            //     {
                                            //         if (item.ID == CategoryID)
                                            //         {
                                            //             conditionStr = item.Category_name;
                                            //             checkTF=false;
                                            //             break;
                                            //         }
                                            //     }
                                            // }
                                            // checkTF = true;
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
                                                //*
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
                                                        // text = "Enter quantity: ";
                                                        // string quantity = CS.OnlyEnterNumber(text);
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
                                                            // Console.WriteLine("Add {0} to order.\n press [Enter] key to confirm or [Esc] back to list clothes.", clothesName);
                                                            // bool checkTFInfoCL = true;
                                                            // while(checkTFInfoCL)
                                                            // {
                                                            //     checkKey = Console.ReadKey(true);
                                                            //     if(checkKey.Key == ConsoleKey.Escape)
                                                            //     {
                                                            //         checkTFInfoCL = false;
                                                            //     }else if(checkKey.Key == ConsoleKey.Enter)
                                                            //     {
                                                            //         orderDetails = new OrderDetails();
                                                            //         statusOrder = 1;
                                                            //         text = "Enter quantity: ";
                                                            //         // string quantity = CS.OnlyEnterNumber(text);
                                                            //         if (quantity == "EXIT")
                                                            //         {
                                                            //             break;
                                                            //         }
                                                            //         int quantityOrder = Convert.ToInt32(quantity);
                                                            //         int Unit_price=0;
                                                            //         foreach (Clothes item in ListClothes)
                                                            //         {
                                                            //             if(item.ID == ID)
                                                            //             {
                                                            //                 Unit_price=item.Unit_price;
                                                            //                 break;
                                                            //             }
                                                            //         }
                                                            //         foreach (Size_color item_SizeColor in ListSizeColor)
                                                            //         {
                                                            //             if (item_SizeColor.clothes_ID == ID)
                                                            //             {
                                                            //                 item_SizeColor.Quantity -= quantityOrder;
                                                            //                 break;
                                                            //             }
                                                            //         }
                                                            //         order.TotalPrice += Unit_price*quantityOrder;
                                                            //         int checkQuantity=0;
                                                            //         foreach (OrderDetails item in ListOrderDetail)
                                                            //         {
                                                            //             if (item.ClothesID == ID)
                                                            //             {
                                                            //                 item.Quantity += quantityOrder;
                                                            //                 checkQuantity =1;
                                                            //                 break;
                                                            //             }
                                                            //         }
                                                            //         if (checkQuantity==0)
                                                            //         {
                                                            //             orderDetails  = ordDtlsBL.addClothesToOrder(order.OrderID, ID, Unit_price, quantityOrder);
                                                            //             ListOrderDetail.Add(orderDetails);
                                                            //         }
                                                            //         checkTFInfoCL = false;
                                                            //     }
                                                            // }}
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 3:
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
                                            }
                                            else if (statusOrder == 1 && checkStr == "ENTER")
                                            {
                                                int orderCompletion = 0;
                                                checkOrderdetail = CS.ShowOrderDetails(order, ListOrderDetail, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, customer.Name, customer.PhoneNumber, staff.NameStaff);
                                                if (checkOrderdetail == null)
                                                {
                                                    break;
                                                }else if (checkOrderdetail.Count() == 0)
                                                {
                                                    filterChoice = 4;
                                                }else
                                                {
                                                    oBL.InsertOrder(order, ListOrderDetail);
                                                    oBL.updateDataMysql(ListSizeColor, ListOrderDetail);
                                                    filterChoice = 4;
                                                }
                    //                             do
                    //                             {
                    //                                 orderCompletion = CS.MenuHandle(@"
                    // =============================================================================================================================
                    // |                                                                                                                           |
                    // |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    // |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    // |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    // |                                                                                                                           |
                    // =============================================================================================================================
                    // |                                                                                                                           |
                    // |                                               ----Show order----                                                          |", confirmOrderMenu, infoStaff, infoCustomer);
                    //                                 switch (orderCompletion)
                    //                                 {
                    //                                     case 1:
                    //                                         checkOrderdetail = CS.ShowOrderDetails(order, ListOrderDetail, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, customer.Name, customer.PhoneNumber, staff.NameStaff);
                    //                                         break;
                    //                                     case 2:
                    //                                         oBL.InsertOrder(order, ListOrderDetail);
                    //                                         oBL.updateDataMysql(ListSizeColor, ListOrderDetail);
                    //                                         break;
                    //                                     case 3:
                    //                                         break;
                    //                                     default:
                    //                                         break;
                    //                                 }
                    //                                 if (checkOrderdetail == null)
                    //                                 {
                    //                                     break;
                    //                                 }
                    //                             }while (orderCompletion != 2 && orderCompletion != 3 && orderCompletion !=0);
                                            }else if (checkStr == "ESCAPE")
                                            {
                                                return;
                                            }else if (checkStr == "TAB")
                                            {
                                                break;
                                            }
                                            break;
                                        case 4:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            break;
                        case 2:
                            Count =0;
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
