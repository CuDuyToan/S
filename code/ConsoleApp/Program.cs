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
        Ultilities CS = new Ultilities();
        Clothes clothes = new Clothes();
        Staff staff = new Staff(); 
        Customer customer = new Customer();

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
        
        string[] cashierMenu = { "Create Order", "Confirm Order", "Log Out" };
        string[] OrderMenu = { "Create Order", "Employee Details", "Log Out" };
        string[] loginMenu = { "Login", "Exit" };
        string[] filterMenu = {"Category", "ID"};
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
        do
        {
            Console.Clear();
            CS.Title(@"
                        ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐
                        ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘
                        ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴  
                    ");
            if (Count == 1)Console.WriteLine(" [!]Username or password incorrect.");
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
                username = "@" + username;
                int clID;
                bool active = true;
                bool activeSub = true;
                while(active)
                {
                    Console.Clear();
                    int orderChoice = CS.MenuHandle(@"
                            ╔═╗┬─┐┌┬┐┌─┐┬─┐  ╔═╗┬ ┬┌─┐┬┌─┐┌─┐  
                            ║ ║├┬┘ ││├┤ ├┬┘  ║  ├─┤│ │││  ├┤   
                            ╚═╝┴└──┴┘└─┘┴└─  ╚═╝┴ ┴└─┘┴└─┘└─┘  
                    ", OrderMenu, username, staff.NameStaff);
                    switch (orderChoice)
                    {
                        // tao mot order moi
                        case 1:
                            while (activeSub)
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
                                        Console.WriteLine(" use phone number [{0}]\n press any key to continue or [Esc] to re-enter the phone number", phoneNum);
                                        checkKey = Console.ReadKey(true);
                                        if (checkKey.Key != ConsoleKey.Escape)
                                        {
                                            int checkCustomer = 0;
                                            foreach (Customer item in ListCustomer)
                                            {
                                                if(item.PhoneNumber == phoneNum){
                                                    customer=item;
                                                    checkCustomer =1;
                                                    activeSub = false;
                                                }
                                            }
                                            if (checkCustomer == 0)
                                            {
                                                cBL.newCustomer(phoneNum);
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
                            Console.Clear();
                            int filterChoice = CS.MenuHandle(@"
                                ┌─┐┬┬  ┌┬┐┌─┐┬─┐
                                ├┤ ││   │ ├┤ ├┬┘
                                └  ┴┴─┘ ┴ └─┘┴└─
                            ", filterMenu);
                            switch (filterChoice)
                            {
                                case 1:
                                    Console.WriteLine("Enter Category: ");
                                    string Category = Console.ReadLine() ??"";
                                    bool checkTF = true;
                                    while (checkTF)
                                    {
                                        Console.Clear();
                                        CS.Title(@"
            ┬  ┬┌─┐┌┬┐  ┌─┐┌─┐  ┌─┐┬  ┌─┐┌┬┐┬ ┬┌─┐┌─┐  ┌┐ ┬ ┬  ┌─┐┌─┐┌┬┐┌─┐┌─┐┌─┐┬─┐┬ ┬
            │  │└─┐ │   │ │├┤   │  │  │ │ │ ├─┤├┤ └─┐  ├┴┐└┬┘  │  ├─┤ │ ├┤ │ ┬│ │├┬┘└┬┘
            ┴─┘┴└─┘ ┴   └─┘└    └─┘┴─┘└─┘ ┴ ┴ ┴└─┘└─┘  └─┘ ┴   └─┘┴ ┴ ┴ └─┘└─┘└─┘┴└─ ┴ 
        ");
                                        Console.WriteLine("| {0,4} | {1, 50} | {2, 12} | {3, 20} | {4, 4} | {5, 10} |", "ID", "Name", "Unit price", "categoryName", "size", "color");
                                        CS.Line();
                                        clBL.GetClothesByCategory(Category, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                        Console.WriteLine("Enter ID to view product details.\n[Or] Enter 0 to exit.");
                                        // int.TryParse(Console.ReadLine(), out clID);
                                        int.TryParse(Console.ReadLine(), out clID);
                                        string clothesName;
                                        if (clID != 0)
                                        {
                                            clothesName = clBL.getInfoClothes(clID, ListCategories, ListClothes, ListSizeColor, ListSize, ListColor);
                                            Console.WriteLine("add {0} to order.\n press any key to confirm or [Esc] back to list clothes.", clothesName);
                                            checkKey = Console.ReadKey(true);
                                            if(checkKey.Key != ConsoleKey.Escape)
                                            {
                                                
                                            }
                                        }else
                                        {
                                            checkTF = false;
                                        }
                                    }
                                    break;
                                case 2:
                                    
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            return;
                        default:
                            break;
                    }
                }
            }

        } while (true);
    }
}
