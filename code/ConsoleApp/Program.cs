using BL;
using Persistence;
using DAL;
using CS;
using MySqlConnector;
using System;
using System.Text;
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

        List<Clothes> ListClothes = new List<Clothes>();
        List<Color> ListColor = new List<Color>();
        List<Customer> ListCustomer = new List<Customer>();
        List<Size_color> ListSizeColor = new List<Size_color>();
        List<Size> ListSize = new List<Size>();
        List<Staff> listStaff = new List<Staff>();
        List<Order> ListOrder = new List<Order>();
        List<OrderDetails> ListOrderDetail = new List<OrderDetails>();
        List<Categories> ListCategories = new List<Categories>();
        List<rowPageSpl> ListRowPage = new List<rowPageSpl>();
        
        string[] cashierMenu = { "Create Order", "Confirm Order", "Log Out" };
        string[] OrderMenu = { "Create Order", "Log Out" };
        string[] loginMenu = { "Login", "Exit" };
        string[] filterMenu = {"List item", "Category", "Back Menu"};
        string username = "", pwd="";
        string phoneNum= "";
        StaffBL uBL = new StaffBL();

        ListClothes = clBL.GetAllProduct();
        listStaff = stBL.GetAllAccount();
        ListCustomer = cBL.GetAllCustomer();
        ListColor = colBL.GetListColor();
        ListSize = sBL.GetListSize();
        ListSizeColor = szclBL.GetSize_Colors();
        ListCategories = cgrBL.GetCategories();

        ConsoleKeyInfo checkKey;
        int Count =0;
        int checkPass =0;
        string conditionStr = "";
        string text, checkStr;
        bool checkTF = true;
        do
        {
            Console.Clear();
            CS.Title(@"
                                    ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐
                                    ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘
                                    ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴  
                    ");
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
            }
            if(username == "RE-ENTER")
            {
                Count = 0;
            }else
            {
                Console.Write(" PassWord: ");
                pwd = CS.hidePassword();
                if(pwd == "EXIT")Count =0;
                if(pwd != "RE-ENTER")
                {
                    foreach (Staff item in listStaff)
                    {
                        if (item.UserName == username && item.Password == pwd)
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
                bool activeNum = true, activeNum2 = true;
                while(active)
                {
                    Console.Clear();
                    int orderChoice = CS.MenuHandle(@"
                                    ╔═╗┬─┐┌┬┐┌─┐┬─┐  ╔═╗┬ ┬┌─┐┬┌─┐┌─┐  
                                    ║ ║├┬┘ ││├┤ ├┬┘  ║  ├─┤│ │││  ├┤   
                                    ╚═╝┴└──┴┘└─┘┴└─  ╚═╝┴ ┴└─┘┴└─┘└─┘  
                    ", OrderMenu, infoStaff);
                    phoneNum = "";
                    switch (orderChoice)
                    {
                        // tao mot order moi
                        case 1:
                            while (activeNum)
                            {
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
                                        Console.WriteLine("\nUse phone number [{0}]\n Press [Enter] key to continue or [Esc] to re-enter the phone number", phoneNum);
                                        activeNum2=true;
                                        while (activeNum2)
                                        {
                                            checkKey = Console.ReadKey(true);
                                            if (checkKey.Key == ConsoleKey.Enter)
                                            {
                                                int checkCustomer = 0;
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
                                                    cBL.newCustomer(phoneNum);
                                                    checkCustomer = 1;
                                                    activeNum = false;
                                                    activeNum2 = false;
                                                }
                                            }else if (checkKey.Key == ConsoleKey.Escape)
                                            {
                                                activeNum = false;
                                                activeNum2 = false;
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
                            if(phoneNum == "EXIT")
                            {
                                break;
                            }
                            int filterChoice = 0;
                            string infoCustomer = "[Customer : <phone> " + customer.PhoneNumber + " | <name> " + customer.Name + " ]";
                            while(filterChoice != 3)
                            {
                                Console.Clear();
                                filterChoice = CS.MenuHandle(@"
                                                ┌─┐┬┬  ┌┬┐┌─┐┬─┐
                                                ├┤ ││   │ ├┤ ├┬┘
                                                └  ┴┴─┘ ┴ └─┘┴└─
                                ", filterMenu, infoStaff, infoCustomer);
                                switch (filterChoice)
                                {
                                    case 1:
                                        text = "Are you sure you want to show all the clothes?\nPress [Enter] to continue or [Esc] to return to the filter menu.";
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
                                                Console.WriteLine("add {0} to order.\n press [Enter] key to confirm or [Esc] back to list clothes.", clothesName);
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
                                    case 2:
                                        text = "Are you sure you want to select [Category]?\nPress [Enter] to continue or [Esc] to return to the filter menu.";
                                        checkStr = CS.pressEnterEsc(text);
                                        string Category="";
                                        conditionStr = "";
                                        if (checkStr == "Esc")
                                        {
                                            break;
                                        }
                                        checkTF=true;
                                        while (checkTF)
                                        {
                                            int count = 1;
                                            CS.Line();
                                            Console.Clear();
                                            string str ="";
                                            Console.Write(str);
                                            foreach (Categories item in ListCategories)
                                            {
                                                Console.WriteLine("{0}. {1}.", count, item.Category_name);
                                                count++;
                                            }
                                            CS.Line();
                                            Console.WriteLine("Enter Category: ");
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
                                                Console.WriteLine("add {0} to order.\n press [Enter] key to confirm or [Esc] back to list clothes.", clothesName);
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
                            break;
                        case 2:
                            return;
                        default:
                            break;
                    }
                }
            }

        } while (true);
    }
}
