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
        List<Order> ListOrder;
        List<OrderDetails> ListOrderDetail;
        
        string[] cashierMenu = { "Create Order.", "Confirm Order.", "Log Out." };
        string[] OrderMenu = { "Create New Order.", "Log Out." };
        string[] loginMenu = { "Login.", "Exit." };
        string[] filterMenu = {"Show All.", "Show List Clothes By Category.", "Back Menu."};
        StaffBL uBL = new StaffBL();

        ListClothes = clBL.GetAllProduct();
        listStaff = stBL.GetAllAccount();
        ListColor = colBL.GetListColor();
        ListSize = sBL.GetListSize();
        ListSizeColor = szclBL.GetSize_Colors();
        ListCategories = cgrBL.GetCategories();

        ConsoleKeyInfo checkKey;
        int Count =0;
        string conditionStr = "";
        string text, checkStr;
        bool checkTF = true, checkLogin = true;
        string username = "", pwd="";
        do
        {
            int checkPass =0;
            Console.Clear();
            CS.Title(@"
                                    ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐    
                                    ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘    
                                    ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴  
                    ");
            Console.WriteLine("[Esc] to back and exit.");
            Console.WriteLine("[Backspace] to delete text.");
            Console.WriteLine("[Enter] to complete text.");
            if (Count == 1)Console.WriteLine("[!]Username or password incorrect.");
            Console.Write(" UserName: ");
            if (Count ==0)
            {
                username = CS.enterString();
                Count =1;
            }else{
                Console.WriteLine(username);
            }
            if(username == "EXIT")
            {
                Console.WriteLine("\nExiting...");
                break;
            }else if(username == "RE-ENTER")
            {
                Count = 0;
            }else if (username != "EXIT" && username != "RE-ENTER")
            {
                Console.Write(" Password: ");
                pwd = CS.hidePassword();
                Count = 1;
//<><><><><><><><><><><><><><><><><><><><><><><><>
                // given, a password in a string
                string password = pwd;

                // byte array representation of that string
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

                // need MD5 to calculate the hash
                byte[] hash = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

                // string representation (similar to UNIX format)
                string encoded = BitConverter.ToString(hash)
                // without dashes
                .Replace("-", string.Empty)
                // make lowercase
                .ToLower();

                // encoded contains the hash you want
//<><><><><><><><><><><><><><><><><><><><><><><><>
                if(pwd == "EXIT")
                {
                    Count =0;
                }else if(pwd != "RE-ENTER" && pwd != "EXIT")
                {
                    foreach (Staff item in listStaff)
                    {
                        if (item.UserName == username && item.Password == encoded)
                        {
                            checkPass = 1;
                            staff = item;
                        }
                    }
                }else
                {
                    Count =2;
                }
            }
            // int checkPass = uBL.Authorize(username, pwd);
            if (checkPass == 1)
            {
                string[] unprocessedAction = { "Change Status To Processing...", "Back To Previous Menu" };
                string[] processingAction = { "Change Status To Completed", "Back To Previous Menu" };
                // int ordID;
                string infoStaff = "[Staff: @" + username + " | " + staff.NameStaff + " ]";
                // int clID;
                bool active = true;
                // bool activeSub = true, activeSub2 = true;
                while(active)
                {
                    bool activeNum = true, activeNum2 = true;
                    Console.Clear();
                    int orderChoice = CS.MenuHandle(@"
                                    ╔═╗┬─┐┌┬┐┌─┐┬─┐  ╔═╗┬ ┬┌─┐┬┌─┐┌─┐  
                                    ║ ║├┬┘ ││├┤ ├┬┘  ║  ├─┤│ │││  ├┤   
                                    ╚═╝┴└──┴┘└─┘┴└─  ╚═╝┴ ┴└─┘┴└─┘└─┘  
                    ", OrderMenu, infoStaff);
                    switch (orderChoice)
                    {
                        // tao mot order moi
                        case 1:
                            string phoneNum = "";
                            ListCustomer = cBL.GetAllCustomer();
                            while (activeNum)
                            {
                                ListOrderDetail = new List<OrderDetails>();
                                int status = 0;
                                order = oBL.createNewOrder(customer.ID, customer.PhoneNumber, staff.ID, staff.NameStaff, status);
                                // ListOrder.Add(order);
                                Console.Clear();
                                CS.Title(@"
                            ╔═╗┬─┐┌─┐┌─┐┌┬┐┌─┐  ┌┐┌┌─┐┬ ┬  ┌─┐┬─┐┌┬┐┌─┐┬─┐
                            ║  ├┬┘├┤ ├─┤ │ ├┤   │││├┤ │││  │ │├┬┘ ││├┤ ├┬┘
                            ╚═╝┴└─└─┘┴ ┴ ┴ └─┘  ┘└┘└─┘└┴┘  └─┘┴└──┴┘└─┘┴└─
                                ");
                                Console.Write("Phone number: ");
                                phoneNum = CS.enterPhone();
                                if (phoneNum != "RE-ENTER" && phoneNum != "EXIT")
                                {
                                    if (phoneNum.Length==10)
                                    {
                                        activeNum2=true;
                                        int checkCustomer = 0;
                                        while (activeNum2)
                                        {
                                            Console.Clear();
                                            if (checkCustomer == 0)
                                            {
                                                Console.WriteLine("\nUse phone number [{0}].\n[Enter] key to continue.\n[Backspace] to re-enter the phone number.\n[Esc] to back Order Choice.", phoneNum);
                                            }else if(checkCustomer == 1)
                                            {
                                                Console.WriteLine("successfully added new customers.\n[Enter] to continue");
                                            }
                                            checkKey = Console.ReadKey(true);
                                            if (checkKey.Key == ConsoleKey.Enter)
                                            {
                                                foreach (Customer item in ListCustomer)
                                                {
                                                    if(item.PhoneNumber == phoneNum){
                                                        customer=item;
                                                        checkCustomer =1;
                                                        activeNum = false;
                                                        activeNum2 = false;
                                                    }
                                                }
                                                if (checkCustomer == 0)
                                                {
                                                    customer = cBL.newCustomer(phoneNum, ListCustomer);
                                                    ListCustomer = cBL.GetAllCustomer();
                                                    checkCustomer = 1;
                                                    activeNum = false;
                                                    // activeNum2 = false;
                                                }
                                            }else if (checkKey.Key == ConsoleKey.Escape)
                                            {
                                                activeNum = false;
                                                activeNum2 = false;
                                                phoneNum = "EXIT";
                                            }else if (checkKey.Key == ConsoleKey.Backspace)
                                            {
                                                activeNum2 = false;
                                            }
                                        }
                                    }
                                }else if(phoneNum == "EXIT")
                                {
                                    break;
                                }
                            }
                            
                            int filterChoice = 0;
                            string infoCustomer = "[Customer : <phone> " + customer.PhoneNumber + " | <name> " + customer.Name + " ]";
                            if(phoneNum != "EXIT")
                            {
                                while(filterChoice != 3)
                                {
                                    Console.Clear();
                                    filterChoice = CS.MenuHandle(@"
                                                ┌─┐┬ ┬┌─┐┬ ┬  ┬  ┬┌─┐┌┬┐
                                                └─┐├─┤│ ││││  │  │└─┐ │ 
                                                └─┘┴ ┴└─┘└┴┘  ┴─┘┴└─┘ ┴ 
                                    ", filterMenu, infoStaff, infoCustomer);
                                    switch (filterChoice)
                                    {
                                        case 1:
                                            text = "Are you sure you want to show list by category the clothes?\nPress [Enter] to continue or [Esc] to return to menu {SHOW LIST}.";
                                            checkStr = CS.pressEnterEsc(text);
                                            if (checkStr == "Esc")
                                            {
                                                break;
                                            }
                                            while(checkTF)
                                            {
                                                conditionStr = "";
                                                int ID = 0;
                                                string title = @"
                                                ╦  ┬┌─┐┌┬┐  ╔═╗┬  ┌─┐┌┬┐┬ ┬┌─┐┌─┐
                                                ║  │└─┐ │   ║  │  │ │ │ ├─┤├┤ └─┐
                                                ╩═╝┴└─┘ ┴   ╚═╝┴─┘└─┘ ┴ ┴ ┴└─┘└─┘
                                                ";
                                                ID = CS.PageSplit(ListRowPage, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, title, infoStaff, infoCustomer, conditionStr);
                                                //*
                                                string clothesName;
                                                if (ID != 0)
                                                {
                                                    clothesName = clBL.getInfoClothes(ID, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                                    Console.WriteLine("Add {0} to order.\n press [Enter] key to confirm or [Esc] back to list clothes.", clothesName);
                                                    foreach (Clothes item in ListClothes)
                                                    {
                                                        if (item.Name == clothesName)
                                                        {
                                                            int ClothesID = item.ID;
                                                        }
                                                    }
                                                    bool checkTFInfoCL = true;
                                                    while(checkTFInfoCL)
                                                    {
                                                        checkKey = Console.ReadKey(true);
                                                        if(checkKey.Key == ConsoleKey.Escape)
                                                        {
                                                            checkTFInfoCL = false;
                                                        }else if(checkKey.Key == ConsoleKey.Enter)
                                                        {
                                                            orderDetails  = ordDtlsBL.addClothesToOrder(order.OrderID, clothesID)
                                                            checkTFInfoCL = false;
                                                        }
                                                    }
                                                }else
                                                {
                                                    break;
                                                }
                                            }
                                            break;
                                        case 2:
                                            text = "Are you sure you want to show all the clothes?\nPress [Enter] to continue or [Esc] to return to menu {SHOW LIST}.";
                                            checkStr = CS.pressEnterEsc(text);
                                            string Category="";
                                            conditionStr = "";
                                            if (checkStr == "Esc")
                                            {
                                                break;
                                            }
                                            checkTF=true;
                                            string str ="";
                                            while (checkTF)
                                            {
                                                int count = 1;
                                                CS.Line();
                                                Console.Clear();
                                                Console.Write(str);
                                                foreach (Categories item in ListCategories)
                                                {
                                                    Console.WriteLine("{0}. {1}.", count, item.Category_name);
                                                    count++;
                                                }
                                                CS.Line();
                                                Console.Write("Enter Category: ");
                                                Category = Console.ReadLine() ??"";
                                                foreach (Categories item in ListCategories)
                                                {
                                                    if (item.Category_name == Category)
                                                    {
                                                        conditionStr = Category;
                                                        checkTF=false;
                                                        break;
                                                    }else if(item.Category_name != Category && Category != "")
                                                    {
                                                        str ="[!] Please enter correct.\n";
                                                    }
                                                }
                                            }
                                            checkTF = true;
                                            while (checkTF)
                                            {
                                                int ID = 0;
                                                string title = @"
                        ╦  ┬┌─┐┌┬┐  ╔═╗┬  ┌─┐┌┬┐┬ ┬┌─┐┌─┐  ┌┐ ┬ ┬  ╔═╗┌─┐┌┬┐┌─┐┌─┐┌─┐┬─┐┬ ┬
                        ║  │└─┐ │   ║  │  │ │ │ ├─┤├┤ └─┐  ├┴┐└┬┘  ║  ├─┤ │ ├┤ │ ┬│ │├┬┘└┬┘
                        ╩═╝┴└─┘ ┴   ╚═╝┴─┘└─┘ ┴ ┴ ┴└─┘└─┘  └─┘ ┴   ╚═╝┴ ┴ ┴ └─┘└─┘└─┘┴└─ ┴ 
                                                ";
                                                ID = CS.PageSplit(ListRowPage, ListClothes, ListSizeColor, ListSize, ListColor, ListCategories, title, infoStaff, infoCustomer, conditionStr);
                                                //*
                                                string clothesName;
                                                if (ID != 0)
                                                {
                                                    clothesName = clBL.getInfoClothes(ID, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                                    Console.WriteLine("Add {0} to order.\n press [Enter] key to confirm or [Esc] back to list clothes.", clothesName);
                                                    bool checkTFInfoCL = true;
                                                    while(checkTFInfoCL)
                                                    {
                                                        checkKey = Console.ReadKey(true);
                                                        if(checkKey.Key == ConsoleKey.Escape)
                                                        {
                                                            checkTFInfoCL = false;
                                                        }else if(checkKey.Key == ConsoleKey.Enter)
                                                        {
                                                            checkTFInfoCL = false;
                                                        }
                                                    }
                                                }else
                                                {
                                                    break;
                                                }
                                            }
                                            break;
                                        case 3:
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
