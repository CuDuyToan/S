using BL;
using Persistence;
using DAL;
using CS;
using MySqlConnector;
using System;
class Program
{
    static void Main()
    {
        Ultilities CS = new Ultilities();
        OrderBL oBL = new OrderBL();
        OrderDetailsBL ordDtlsBL = new OrderDetailsBL();
        CustomerBL cBL = new CustomerBL();
        ClothesBL clBL = new ClothesBL();
        ClothesDAL clDAL = new ClothesDAL();
        Clothes clothes = new Clothes(); 
        string[] cashierMenu = { "Create Order", "Confirm Order", "Log Out" };
        string[] OrderMenu = { "Create Order", "Show List Item", "Log Out" };
        string[] cashierSubMenu = { "Add Product To Order", "Show Order", "Back To Main Menu" };
        string[] loginMenu = { "Login", "Exit" };
        string[] filterMenu = {"Category"};
        string username, pwd;
        string phoneNum;
        StaffBL uBL = new StaffBL();
        do
        {
            Console.Clear();
            int loginChoice = CS.MenuHandle(@"
                            ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐
                            ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘
                            ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴  
                            ", loginMenu);
            switch (loginChoice)
            {
                case 1:
                    Console.Clear();
                    CS.Title(@"
                                    ╦  ┌─┐┌─┐┬┌┐┌
                                    ║  │ ││ ┬││││
                                    ╩═╝└─┘└─┘┴┘└┘
                            ");
                    Console.Write(" UserName: ");
                    username = Console.ReadLine() ?? "";
                    Console.Write(" PassWord: ");
                    pwd = Console.ReadLine() ?? "";
                    int roleID = uBL.Authorize(username, pwd);
                    if (roleID == 1)
                    {
                        string[] unprocessedAction = { "Change Status To Processing...", "Back To Previous Menu" };
                        string[] processingAction = { "Change Status To Completed", "Back To Previous Menu" };
                        int ordID;
                        string clID;
                        bool active = true;
                        bool activeSub = true;
                        while(active)
                        {
                            Console.Clear();
                            int orderChoice = CS.MenuHandle(@"
                            ╔═╗┬─┐┌┬┐┌─┐┬─┐  ╔═╗┬ ┬┌─┐┬┌─┐┌─┐
                            ║ ║├┬┘ ││├┤ ├┬┘  ║  ├─┤│ │││  ├┤ 
                            ╚═╝┴└──┴┘└─┘┴└─  ╚═╝┴ ┴└─┘┴└─┘└─┘
                            ", OrderMenu);
                            switch (orderChoice)
                            {
                                // tao mot order moi
                                case 1:
                                    Console.Clear();
                                    CS.Title(@"
                    ╔═╗┬─┐┌─┐┌─┐┌┬┐┌─┐  ┌┐┌┌─┐┬ ┬  ┌─┐┬─┐┌┬┐┌─┐┬─┐
                    ║  ├┬┘├┤ ├─┤ │ ├┤   │││├┤ │││  │ │├┬┘ ││├┤ ├┬┘
                    ╚═╝┴└─└─┘┴ ┴ ┴ └─┘  ┘└┘└─┘└┴┘  └─┘┴└──┴┘└─┘┴└─
                                    ");
                                    Console.Write("Phone number: ");
                                    phoneNum = Console.ReadLine() ??"";
                                    Customer customer = new Customer(); 
                                    cBL.Authorize(phoneNum);
                                    // //add sdt vao file orderData.txt
                                    // File.WriteAllText("orderData.txt", noidung);
                                    // sau khi nhap sdt thi can hien thi danh sach quan ao
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
                                                List<Clothes> clothesByCategory = clBL.GetProductsByCategory(Category);
                                                CS.Title(@"
                ┬  ┬┌─┐┌┬┐  ┌─┐┌─┐  ┌─┐┬  ┌─┐┌┬┐┬ ┬┌─┐┌─┐  ┌┐ ┬ ┬  ┌─┐┌─┐┌┬┐┌─┐┌─┐┌─┐┬─┐┬ ┬
                │  │└─┐ │   │ │├┤   │  │  │ │ │ ├─┤├┤ └─┐  ├┴┐└┬┘  │  ├─┤ │ ├┤ │ ┬│ │├┬┘└┬┘
                ┴─┘┴└─┘ ┴   └─┘└    └─┘┴─┘└─┘ ┴ ┴ ┴└─┘└─┘  └─┘ ┴   └─┘┴ ┴ ┴ └─┘└─┘└─┘┴└─ ┴ 
                ");
                                                Console.WriteLine("| {0,4} | {1, 50} | {2, 9} | {3, 20} |", "ID", "Name", "Price", "Category");
                                                CS.Line();
                                                foreach (Clothes item in clothesByCategory)
                                                {
                                                    Console.WriteLine("| {0,4} | {1, 50} | {2, 9} | {3, 20} |", item.ID, item.Name, item.Price, item.Category);
                                                    CS.Line();
                                                }
                                                Console.WriteLine("Enter ID to view product details.\n[Or] Enter 0 to exit.");
                                                // int.TryParse(Console.ReadLine(), out clID);
                                                clID = Console.ReadLine();
                                                if (clID != "0"){
                                                    // for (int i = 0; i < 1; i++)
                                                    // {
                                                    //     Console.WriteLine("Enter size: ");
                                                    //     string size = Console.ReadLine() ??"";
                                                    //     Console.WriteLine("Enter color: ");
                                                    //     string color = Console.ReadLine() ??"";
                                                    //     Console.Clear();
                                                        
                                                    // }
                                                    clDAL.GetProductByID(clID);
                                                    Console.Clear();
                                                    CS.Line();
                                                    Console.WriteLine("ID:       {0}", clothes.ID);
                                                    Console.WriteLine("Size:     {0}", clothes.Size);
                                                    Console.WriteLine("Name:     {0}", clothes.Name);
                                                    Console.WriteLine("Price:    {0}", clothes.Price);
                                                    Console.WriteLine("Color:    {0}", clothes.Color);
                                                    Console.WriteLine("Material: {0}", clothes.Material);
                                                    Console.WriteLine("Category: {0}", clothes.Category);
                                                    // Console.WriteLine("Name: {0}", clothes.Name);
                                                    Console.ReadKey();
                                                }else{
                                                    break;
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case 3:
                                    return;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case 2:
                    return;
                default:
                    break;

            }
        } while (true);
    }
}
