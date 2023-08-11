using Persistence;
using System.Text;
using System.Security.Cryptography;

namespace CS
{
    public class Ultilities
    {
        public int MenuHandle(string title1, string[] menuItem)//show menu
        {
            int i = 0, choice;
            if(title1 != null)
                Title(title1);
            for (; i < menuItem.Count(); i++)
            {
                System.Console.WriteLine("" + (i+1) + ". " + menuItem[i]);
            }
            Line();
            do
            {
                System.Console.Write("Your choice: ");
                int.TryParse(System.Console.ReadLine(), out choice);
            }while (choice <= 0 || choice > menuItem.Count());
            return choice;
        }

        public int MenuHandle(string title1, string[] menuItem, string str1)//show menu with information of an object
        {
            ConsoleKeyInfo key;
            int row = 0;
            string item = "";
            do
            {
                Console.Clear();
                Console.Write(title1);
                Console.Write(@"
                    |                 {0, 103}   |
                    =============================================================================================================================", str1);
                // if(title1 != null)
                //     Title(title1, str1);
                for (int i=0; i < menuItem.Count(); i++)
                {
                    item = addSpaceToStr(menuItem[i], 82);
                    if (row == i)
                    {
                        System.Console.Write(@"
                    |  👉  {0}                                   |", item);
                    }else System.Console.Write(@"
                    |    {0}                                     |", item );
                }
                Console.Write(@"
                    =============================================================================================================================
                    { 🔽 🔼 } Choice.                                 {Enter} Confirm.                                               ");
                key = Console.ReadKey();
                if(key.Key == ConsoleKey.UpArrow && row > 0)
                {
                    row--;
                }else if (key.Key == ConsoleKey.DownArrow && row < menuItem.Count()-1)
                {
                    row++;
                }else if (key.Key == ConsoleKey.Enter)
                {
                    return row+1;
                }
                // else if (key.Key == ConsoleKey.Escape)
                // {
                //     return -1;
                // }
                else if (key.Key == ConsoleKey .Tab)
                {
                    return 0;
                }
            }while (key.Key != ConsoleKey.Tab);
            return 0;
        }

        public int MenuHandle(string title1, string[] menuItem, string str1, string str2)//show menu with information two object
        {
            ConsoleKeyInfo key;
            int row = 0;
            string item = "";
            do
            {
                Console.Clear();
                Console.Write(title1);
                Console.Write(@"
                    |                 {0, 103}   |
                    |                 {1, 103}   |
                    =============================================================================================================================", str1, str2);
                // if(title1 != null)
                //     Title(title1, str1);
                for (int i=0; i < menuItem.Count(); i++)
                {
                    item = addSpaceToStr(menuItem[i], 82);
                    if (row == i)
                    {
                        System.Console.Write(@"
                    |  👉  {0}                                   |", item);
                    }else System.Console.Write(@"
                    |    {0}                                     |", item );
                }
                Console.Write(@"
                    =============================================================================================================================
                    { 🔽 🔼 } Choice.                                 {Enter} Confirm.                                               ");
                key = Console.ReadKey();
                if(key.Key == ConsoleKey.UpArrow && row > 0)
                {
                    row--;
                }else if (key.Key == ConsoleKey.DownArrow && row < menuItem.Count()-1)
                {
                    row++;
                }else if (key.Key == ConsoleKey.Enter)
                {
                    return row+1;
                }
                // else if (key.Key == ConsoleKey.Escape)
                // {
                //     return -1;
                // }
                else if (key.Key == ConsoleKey .Tab)
                {
                    return 0;
                }
            }while (key.Key != ConsoleKey.Tab);
            // if (key.Key == ConsoleKey.Escape) 
            // {
            //     row = -1;
            // }
            return 0;
        }
        public void Title(string title1)//title on menu
        {
            Line();
            System.Console.WriteLine(" " + title1);
            Line();
        }

        public void Title(string title1, string str1)//title on menu with info of obj
        {
            Line();
            System.Console.Write(" " + title1 + "\n" + str1);
            Line();
        }

        public void Title(string title1, string str1, string str2)//title on menu with info of obj
        {
            Line();
            System.Console.WriteLine(" " + title1 + "\n" + str1 + "                           " + str2);
            Line();
        }
        public void Line(){
            System.Console.Write(@"
                    =============================================================================================================================");
            }                         
        public void PressAnyKeyToContinue(){
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
        public string hidePassword()// hide password in login menu by [*]
        {
            string pwd ="";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if ((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9))
                {
                    pwd += key.KeyChar;
                    Console.Write("*");
                }
                // else if(key.Key == ConsoleKey.Escape){
                //     return "ESCAPE";
                // }
                else if(key.Key == ConsoleKey.Backspace){
                    return "BACKSPACE";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace);
            Console.WriteLine("");
//<><><><><><><><><><><><><><><><><><><><><><><><>
            return pwd;
        }

        public string enterString()
        {
            string str ="";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if ((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9))
                {
                    str += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                // else if(key.Key == ConsoleKey.Escape){
                //     return "ESCAPE";
                // }
                else if(key.Key == ConsoleKey.Backspace){
                    return "BACKSPACE";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");
            return str;
        }

        public string pressEnterTab(string str, string[] menuItem, int choice, string staffInfo, string customerInfo, string text)
        {
            ConsoleKeyInfo key;
            // int row = 0;
            string item;
            do
            {
                Console.Clear();
                Console.Write(str);
                Console.Write(@"
                    |                 {0, 103}   |
                    |                 {1, 103}   |
                    =============================================================================================================================", staffInfo, customerInfo);
                // if(title1 != null)
                //     Title(title1, str1);
                for (int i=0; i < menuItem.Count(); i++)
                {
                    item = addSpaceToStr(menuItem[i], 82);
                    if (choice-1 == i)
                    {
                        System.Console.Write(@"
                    |  👉  {0}                                   |", item);
                    }else System.Console.Write(@"
                    |    {0}                                     |", item );
                }
                Console.Write(@"
                    =============================================================================================================================
                                      {Enter} Confirm.                                               {Tab} Back.");
                Console.Write(text);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    return "ENTER";
                }else if (key.Key == ConsoleKey.Tab)
                {
                    return "TAB";
                }
            }while (key.Key != ConsoleKey.Tab && key.Key != ConsoleKey.Enter);
            // if (key.Key == ConsoleKey.Escape) 
            // {
            //     return "ESCAPE"; 
            // }
            return "TAB";

            // string PressKey = "Esc";
            // ConsoleKeyInfo key;
            // Console.WriteLine(text);
            // key = Console.ReadKey(true);
            // do
            // {
            //     if(key.Key!= ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            //     {
            //         Console.Clear();
            //         Line();
            //         Console.WriteLine(text);
            //         Console.WriteLine("[!]Can only press [Esc] or [Enter].");
            //         key = Console.ReadKey(true);
            //     }
            // } while (key.Key!= ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            // if (key.Key == ConsoleKey.Enter)PressKey = "Enter";
            // return PressKey;
        }
        public string enterPhone()
        {
            string phone = "";
            int count = 0;
            ConsoleKeyInfo key;
            do
            {
                if(count == 10)
                {
                    return phone;
                }
                key = Console.ReadKey(true);
                if ((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9))
                {
                    count ++;
                    phone += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                // else if(key.Key == ConsoleKey.Escape){
                //     return "ESCAPE";
                // }
                else if(key.Key == ConsoleKey.Backspace){
                    return "BACKSPACE";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape);
            Console.WriteLine("");
            return phone;
        }

        public void pageSplit()
        {
            ConsoleKeyInfo key;
            int page=1, row=1;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.RightArrow && page > 1)
                {
                    page++;
                    row = 1;
                }else if(key.Key == ConsoleKey.LeftArrow && page < 10)
                {
                    page--;
                    row = 1;
                }else if(key.Key == ConsoleKey.UpArrow && row < 10)
                {
                    row++;
                }else if(key.Key == ConsoleKey.DownArrow && row > 1)
                {
                    row--;
                }


            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            
        }
        public rowPageSpl updatePageSpl(int No, int ID, string Name, string Size, string Color, int Unit_price, string category)
        {
            rowPageSpl rowPageSpl = new rowPageSpl();
            rowPageSpl.No = No;
            rowPageSpl.ID = ID;
            rowPageSpl.Name =Name;
            rowPageSpl.Size =Size;
            rowPageSpl.Color =Color;
            rowPageSpl.Unit_price =Unit_price;
            rowPageSpl.Category = category;
            return rowPageSpl;
        }
        public List<rowPageSpl> GetListClothesByCategory(List<Clothes> ListClothes, List<Size_color> List_szcl, List<Size> ListSize, List<Color> ListColor, List<Categories> ListCategory, int page, int row, string category)
        {
            Clothes clothes = new Clothes();
            List<rowPageSpl> rowPageSpls = new List<rowPageSpl>();
            rowPageSpl rowpag = new rowPageSpl();
            string nameColor = "", nameSize = "";
            int count = 1;
            int category_ID = 0;
            foreach (Categories item in ListCategory)
            {
                if (item.Category_name == category)
                {
                    category_ID = item.ID;
                    break;
                }
            }
            foreach (Clothes item in ListClothes)
                {
                    if(item.Category_ID == category_ID){
                        foreach (Size_color item_szcl in List_szcl)
                        {
                            if (item.ID == item_szcl.clothes_ID)
                            {
                                foreach (Size item_Size in ListSize)
                                {
                                    if (item_szcl.Size_ID == item_Size.Size_ID)
                                    {
                                        nameSize=item_Size.Size_Name;
                                        break;
                                    }
                                }
                                foreach (Color item_Color in ListColor)
                                {
                                    if (item_szcl.Color_ID == item_Color.Color_ID)
                                    {
                                        nameColor = item_Color.Color_Name;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        rowpag = updatePageSpl(count, item.ID, item.Name, nameSize, nameColor, item.Unit_price, category);
                        rowPageSpls.Add(rowpag);
                        count++;
                    }
                }
            return rowPageSpls;
        }
        public List<rowPageSpl> getListClothes(List<Clothes> ListClothes, List<Size_color> List_szcl, List<Size> ListSize, List<Color> ListColor, List<Categories> ListCategory, int page, int row, string conditionStr)//List<rowPageSpl>
        {
            Clothes clothes = new Clothes();
            List<rowPageSpl> rowPageSpls = new List<rowPageSpl>();
            rowPageSpl rowpag = new rowPageSpl();
            string category = "", nameColor = "", nameSize = "";
            int count = 1;
            if (conditionStr != "")
            {
                rowPageSpls = GetListClothesByCategory(ListClothes, List_szcl, ListSize,ListColor, ListCategory, page, row, conditionStr);
            }else{
                foreach (Clothes item in ListClothes)
                {
                    foreach (Size_color item_szcl in List_szcl)
                    {
                        if (item.ID == item_szcl.clothes_ID)
                        {
                            foreach (Size item_Size in ListSize)
                            {
                                if (item_szcl.Size_ID == item_Size.Size_ID)
                                {
                                    nameSize=item_Size.Size_Name;
                                    break;
                                }
                            }
                            foreach (Color item_Color in ListColor)
                            {
                                if (item_szcl.Color_ID == item_Color.Color_ID)
                                {
                                    nameColor = item_Color.Color_Name;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    foreach (Categories item_Category in ListCategory)
                    {
                        if (item_Category.ID == item.Category_ID)
                        {
                            category = item_Category.Category_name;
                            break;
                        }
                    }
                    rowpag = updatePageSpl(count, item.ID, item.Name, nameSize, nameColor, item.Unit_price, category);
                    rowPageSpls.Add(rowpag);
                    count++;
                }
            }

            return rowPageSpls;
        }
        
        public int PageSplit(List<rowPageSpl> ListRowPage, List<Clothes> ListClothes, List<Size_color> List_szcl, List<Size> ListSize, List<Color> ListColor, List<Categories> ListCategory, string title, string str1, string str2, string conditionStr)
        {
            ConsoleKeyInfo key;
            int ID =0, page=0, row=1, No=1;
            ListRowPage = getListClothes(ListClothes, List_szcl, ListSize, ListColor, ListCategory, page, row, conditionStr);
            int maxcount = 0, maxpage =0;
            foreach (rowPageSpl item in ListRowPage)
            {
                if (maxcount == 10)
                {
                    maxpage++;
                    maxcount=0;
                }
                maxcount++;
            }
            do
            {
                Console.Clear();
                Console.Write(title);
                Console.Write(@"
                    |                 {0, 103}   |
                    |                 {1, 103}   |
                    =============================================================================================================================", str1, str2);
                Console.Write(@"
                    |                                                                                                                           |
                    |       =============================================================================================================       |
                    |       | {0,4} | {1,35} | {2,10} | {3,10} | {4,16} | {5,15} |       |
                    |       =============================================================================================================       |", "No", "Clothes Name", "Color", "Size", "Category", "Unit Price");
                int count =0;
                foreach (rowPageSpl item in ListRowPage)
                {
                    if(item.No>=10*page+1 && item.No<=(10*page+11))
                    {
                    var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                    string price = String.Format(info, "{0:N0}", item.Unit_price);
                        if (item.No == No)
                        {
                            Console.Write(@"
                    |       |");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write(" {0,4} | {1,35} | {2,10} | {3,10} | {4,16} | {5,11} vnđ ", item.No, item.Name, item.Color, item.Size, item.Category, price);
                            Console.ResetColor();
                            Console.Write("|       |");
                        }else
                        {
                            Console.Write(@"
                    |       | {0,4} | {1,35} | {2,10} | {3,10} | {4,16} | {5,11} vnđ |       |", item.No, item.Name, item.Color, item.Size, item.Category, price);
                        }
                        count++;
                        if (count == 10)
                        {
                            break;
                        }
                    }
                }
                if (count<10)
                {
                    int count2 = count;
                    while (count2 < 10)
                    {
                        Console.Write(@"
                    |       | {0,4} | {1,35} | {2,10} | {3,10} | {4,16} | {5,15} |       |", "", "", "", "", "", "");
                        count2++;
                    }
                }
                Console.Write(@"
                    |       =============================================================================================================       |");
                Console.Write(@"
                    |                                                      [{0, 3}/{1, 3}]                                                            |",page+1, maxpage+1);
                Console.Write(@"
                    |                                                                                                                           |
                    =============================================================================================================================
                    {◀️  ▶️ } Choice page.                                         { 🔽 🔼 } Choice row.
                    {Enter} Confirm.                                               {Tab} Back.");
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.RightArrow && page < maxpage)
                {
                    page++;
                    row = 1;
                    No = 10*page + row;
                }else if(key.Key == ConsoleKey.LeftArrow && page > 0)
                {
                    page--;
                    row = 1;
                    No = 10*page + row;
                }else if(key.Key == ConsoleKey.DownArrow && row < count)
                {
                    row++;
                    No++;
                }else if(key.Key == ConsoleKey.UpArrow && row > 1)
                {
                    row--;
                    No--;
                }else if(key.Key == ConsoleKey.Tab)
                {
                    return 0;
                }
                // else if(key.Key == ConsoleKey.Enter)
                // {
                //     return No;
                // }
                // else if(key.Key == ConsoleKey.Escape)
                // {
                //     return -1;
                // }


            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Tab);
            if (No!= 0)
            {
                foreach (rowPageSpl item in ListRowPage)
                {
                    if (item.No == No)
                    {
                        foreach (Clothes item_clothes in ListClothes)
                        {
                            if (item.ID == item_clothes.ID)
                            {
                                ID = item_clothes.ID;
                                break;
                            }
                        }
                        break;
                    }
                }
            }else
            {
                ID = No;
            }
            return ID;
        }

        public string OnlyEnterNumber(string text)
        {
            string number = "";
            Console.WriteLine(text);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if ((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9))
                {
                    number += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                // else if(key.Key == ConsoleKey.Escape){
                //     return "ESCAPE";
                // }
                else if(key.Key == ConsoleKey.Backspace){
                    Console.Clear();
                    Console.WriteLine(text);
                    number = "";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Tab);
            if(number == "")number="1";
            return number;
        }

        public Staff LoginMenu(List<Staff> listStaff)
        {
            Staff staff = new Staff();
            int row = 1;
            string report = "";
            string username = staff.UserName + "_", password = staff.Password;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |               username : {0}               |
                    |               password : {1}               |
                    |                                                                                                                           |
                    =============================================================================================================================", addSpaceToStr("["+username+"]", 82), addSpaceToStr("["+password+"]", 82));
                    Console.Write(@"
                    {Backspace} Delete text.                      {Enter} Confirm.
                    { 🔽 🔼 } Choice.  ");                            
                                         //    00000000011111111122222222223333333333444444444455555555555666666666677777777778888888889999999999 
                Console.WriteLine(report);
                username = staff.UserName;
                password = hideWord(staff.Password);
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && row > 1)
                {
                    row--;
                }else if (key.Key == ConsoleKey.DownArrow && row < 2)
                {
                    row++;
                }
                if (((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9)) && row == 1)
                {
                    staff.UserName += key.KeyChar;
                }else if (key.Key == ConsoleKey.Backspace && row == 1 && staff.UserName.Length > 0)
                {
                    int delete = staff.UserName.Length-1;
                    staff.UserName = staff.UserName.Substring(0, delete);
                }else if (((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9)) && row == 2)
                {
                    staff.Password += key.KeyChar;
                }else if (key.Key == ConsoleKey.Backspace && row == 2 && staff.Password.Length > 0)
                {
                    // int delete = staff.Password.Length-1;
                    // staff.Password = staff.Password.Substring(0, delete); delete char

                    staff.Password = ""; // delete all
                }
                else if (key.Key == ConsoleKey.Enter && row == 2)
                {
//<><><><><><><><><><><><><><><><><><><><><><><><>
                    // byte array representation of that string
                    byte[] encodedPassword = new UTF8Encoding().GetBytes(staff.Password);

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
                    foreach (Staff item in listStaff)
                    {
                        if (staff.UserName == item.UserName && encoded == item.Password)
                        {
                            return item;
                        }
                    }
                    report = @"
                    [!]{username} or {password} incorrect.";
                }
                else if (key.Key == ConsoleKey.Enter && row ==1)
                {
                    row++;
                }
                else if (key.Key ==  ConsoleKey.Tab)
                {
                    staff.Password = "";
                    staff.UserName = "";
                    return staff;
                }
                if (row == 1)
                {
                    username = staff.UserName + "_";
                }else if (row == 2)
                {
                    password = hideWord(staff.Password)+"_";
                }
            } while (key.Key != ConsoleKey.Tab);
            staff.Password = "";
            staff.UserName = "";
            return staff;
        }

        public void userManual()
        {
            // Console.Write(@"
            //         | {Esc} Exit.                   {Enter} Complete.              {Back Space ⇽  } Delete text.                                |
            //         | {◀️  ▶️  🔽 🔼 } choice.                                                                                                    |
            //         =============================================================================================================================");
            Console.Write(@"
                        {Esc} Exit / Cancel.                   {Enter} Complete / Confirm.              {Back Space ⇽  } Delete text.
                        {Tab} Back.                            {◀️  ▶️  🔽 🔼 } choice.
");
        }

        // public char EnterChar()
        // {
        //     ConsoleKeyInfo key;
        //     do
        //     {
        //         key = Console.ReadKey();
        //         if ((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9))
        //         {
        //             return key.KeyChar;
        //         }
        //     } while (key.Key != ConsoleKey. &&);
        // }
        
        public string hideWord(string word)
        {
            string hideWord = "";
            for (int i = 0; i < word.Length; i++)
            {
                hideWord += "*";
            }
            return hideWord;
        }
        public string addSpaceToStr(string str, int a)
        {
            int spaceCount =  a-str.Length;
            string strSpace = str;
            for (int i = 0; i < spaceCount; i++)
            {
                strSpace = strSpace + " ";
            }
            return strSpace;
        }

        public Customer enterPhoneCustomer(List<Customer> listCustomer, string staffInfo)
        {
            Customer customer = new Customer();
            string phoneNum ="";
            string report = "";
            bool check = true;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                phoneNum = customer.PhoneNumber;
                Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                            ----Creter new order----                                                       |
                    |                 {0, 103}   |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |               Phone Number : {1}           |
                    |                                                                                                                           |
                    =============================================================================================================================",staffInfo, addSpaceToStr("["+phoneNum+"_]", 82));
                    Console.Write(@"
                                                {Backspace} delete text.                    {Tab} Back.  ");
                                         //    00000000011111111122222222223333333333444444444455555555555666666666677777777778888888889999999999 
                    // userManual();
                Console.Write(@"
                    {0}", report);
                report = "";
                key = Console.ReadKey(true);
                if (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9 && customer.PhoneNumber.Length < 10)
                {
                    customer.PhoneNumber += key.KeyChar;
                }else if (key.Key == ConsoleKey.Backspace && customer.PhoneNumber.Length > 0 && customer.PhoneNumber.Length < 10)
                {
                    int delete = customer.PhoneNumber.Length-1;
                    customer.PhoneNumber = customer.PhoneNumber.Substring(0, delete);
                }else if (key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z && customer.PhoneNumber.Length < 10)
                {
                    report = @"
                    [!] Only enter number.";
                }
                else if (key.Key == ConsoleKey.Enter && customer.PhoneNumber.Length == 10)
                {
                    foreach (Customer item in listCustomer)
                    {
                        if (customer.PhoneNumber == item.PhoneNumber)
                        {
                            return item;
                        }
                    }
                    check = false;
                }
                else if(key.Key == ConsoleKey.Backspace && customer.PhoneNumber.Length >= 10)
                {
                    customer.PhoneNumber ="";
                }
                // else if (key.Key == ConsoleKey.Escape)
                // {
                //     customer.Name = "ESCAPE";
                //     return customer;
                // }
                else if (key.Key == ConsoleKey.Tab)
                {
                    customer.Name = "TAB";
                    return customer;
                }
                // else
                // phoneNum = customer.PhoneNumber + "_";
                 if (customer.PhoneNumber.Length == 10)
                {
                    report = @"
                    [?] User phone number "+ customer.PhoneNumber + @".
                    {Enter} Confirm.
                    {Back space} Re-Enter.";
                }
            } while (check == true);
            customer.Name = "";
            return customer;
        }

        public string newCustomer(string staff, string phoneNumber, string report)
        {
            ConsoleKeyInfo key;
            string namecustomer="";
            string text = "";
            do
            {
                Console.Clear();
                Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                                ----New customer----                                                       |
                    |                 {0, 103}   |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                 Phone Number   : {1, 10}                                                                             |
                    |                 Name Customer  : {2}         |
                    |                                                                                                                           |
                    =============================================================================================================================
                    {Tab} Back.                                                                                      {Backspace} Delete text", staff, "["+phoneNumber+"]", addSpaceToStr("["+namecustomer+"_]", 80));
                Console.Write(@"
                    {0}", report);
                report = "";
                key = Console.ReadKey(true);
                if (((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) || key.Key == ConsoleKey.Spacebar) && namecustomer.Length < 80)
                {
                    namecustomer += key.KeyChar;
                }else if (key.Key == ConsoleKey.Enter && namecustomer != "")
                {
                    return namecustomer;
                }else if (key.Key == ConsoleKey.Enter && namecustomer == "")
                {
                    report = "[!] ERROR! Pls enter name customer.";
                }else if (key.Key == ConsoleKey.Backspace && namecustomer.Length > 0)
                {
                    int delete = namecustomer.Length-1;
                    namecustomer = namecustomer.Substring(0, delete);
                }else if (key.Key == ConsoleKey.Tab)
                {
                    return "TAB";
                }
                
            } while (key.Key != ConsoleKey.Tab);
            return "TAB";
        }

        public string showInfoClothes(int ID, List<Categories> categories, List<Clothes> clothesList, List<Size_color> szclList, List<Size> size, List<Color> color)
        {
            string OrderQuantity = "1";
            string text = @"
                    {Enter} To enter the quantity
                    [!] Default = 1.";
            string report = "";
            int count = 0;
            Clothes clothes = new Clothes();
            ConsoleKeyInfo key;
            foreach (Clothes item in clothesList)
            {
                if (item.ID == ID)
                {
                    clothes = item;
                    break;
                }
            }
            string sizeName ="Size", colorName="color", categoryName="Category";
            int quantity = 0;
            foreach (Categories item in categories)
            {
                if (item.ID == clothes.Category_ID)
                {
                    categoryName = item.Category_name;
                    break;
                }
            }
            foreach (Size_color item in szclList)
            {
                if (item.clothes_ID == clothes.ID)
                {
                    foreach (Size item_size in size)
                    {
                        if (item.Size_ID == item_size.Size_ID)
                        {
                            sizeName = item_size.Size_Name;
                            break;
                        }
                    }
                    foreach (Color item_color in color)
                    {
                        if (item.Color_ID == item_color.Color_ID)
                        {
                            colorName = item_color.Color_Name;
                            break;
                        }
                    }
                    quantity = item.Quantity;
                    break;
                }
            }
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            string price = String.Format(info, "{0:N0}", clothes.Unit_price);
            do
            {
            Console.Clear();
            Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                               ----Info clothes----                                                        |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |       =============================================================================================================       |
                    |       |                                                                                                           |       |
                    |       |  ID          : {0}  |       |
                    |       |  Name        : {1}  |       |
                    |       |  Size        : {2}  |       |
                    |       |  Color       : {3}  |       |
                    |       |  Category    : {4}  |       |
                    |       |  Material    : {5}  |       |
                    |       |  Quantity    : {6}  |       |
                    |       |  Price       : {7}  |       |
                    |       |  User Manual : {8}  |       |
                    |       |                                                                                                           |       |  
                    |       =============================================================================================================       |
                    |                                                                                                                           |
                    =============================================================================================================================", addSpaceToStr(Convert.ToString(ID), 89), addSpaceToStr(clothes.Name, 89), addSpaceToStr(sizeName, 89), addSpaceToStr(colorName, 89), addSpaceToStr(categoryName, 89), addSpaceToStr(clothes.Material, 89), addSpaceToStr(Convert.ToString(quantity), 89), addSpaceToStr(price + " vnđ", 89), addSpaceToStr(clothes.user_manual, 89));
                if (count == 1)
                {
                    Console.Write(@"
                    |       Quantity : [" + addSpaceToStr(OrderQuantity+"_]", 97) + @"       |
                    =============================================================================================================================");
                }
                if (OrderQuantity != "")
                {
                    if (Convert.ToInt32(OrderQuantity) > quantity)
                    {
                        report = report +@"
                    [!] The order quantity exceeds the quantity of the clothes.";
                    }
                }
                Console.Write(text);
                // userManual();
                Console.Write(report);
                report = "";
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter && OrderQuantity == "1")
                {
                    OrderQuantity = "";
                    count =1;
                }
                // else if (key.Key == ConsoleKey.Escape)
                // {
                //     return "ESCAPE";
                // }
                else if ((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) && OrderQuantity.Length <= 3 && count ==1)
                {
                    OrderQuantity += key.KeyChar;
                }else if ((key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) && OrderQuantity.Length > 3 && count ==1)
                {
                    report = @"
                    [!] Max value!";
                }
                else if (key.Key == ConsoleKey.Backspace && OrderQuantity.Length > 0)
                {
                    int delete = OrderQuantity.Length - 1;
                    OrderQuantity = OrderQuantity.Substring(0, delete);
                }else if (key.Key == ConsoleKey.Enter && count == 1)
                {
                    if (OrderQuantity == "")
                    {
                        return "1";
                    }else if (OrderQuantity != "" && Convert.ToInt32(OrderQuantity) <= quantity)
                    {
                        return OrderQuantity;
                    }
                }else if (key.Key == ConsoleKey.Tab)
                {
                    return "TAB";
                }
                // else if (key.Key == ConsoleKey.Escape)
                // {
                //     return "BACK";
                // }
            } while (key.Key != ConsoleKey.Tab);
            return "TAB";
        }

        // public int EnterQuantity()
        // {
        //     int quantity = 1;
        //     ConsoleKeyInfo key;
        //     do
        //     {
                
        //     } while (key.Key = console);
        //     return quantity
        // }

        public List<OrderDetails> ShowOrderDetails(Order order, List<OrderDetails> ListOrderDetail, List<Clothes> listClothes, List<Size_color> listSzcl, List<Size> listSize, List<Color> listColor,List<Categories> listCategory, string CustomerName, string CustomerPhone, string NameStaff)
        {
            ConsoleKeyInfo key;
            int count = 1, row = 1, maxRow = 0;
            string ClothesName ="";
            int price = 0, ID = 0;
            string size="", color="", category="", name="";
            Clothes clothes = new Clothes();
            do
            {
                Console.Clear();
                // row = 1;
                maxRow=0;
                Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                            ----Show order detail----                                                      |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |       ▒███████▒ ╔═╗┬  ┌─┐┌┬┐┬ ┬┌─┐┌─┐                                 ╔╗   ╦  ╦    ╦                                      |
                    |       ▒ ▒ ▒ ▄▀░ ║  │  │ │ │ ├─┤├┤ └─┐                                 ╠╩╗  ║  ║    ║                                      |
                    |       ░ ▒ ▄▀▒░  ╚═╝┴─┘└─┘ ┴ ┴ ┴└─┘└─┘                                 ╚═╝  ╩  ╩═╝  ╩═╝                                    |
                    |         ▄▀▒   ░   Đaã Nghĩ tới, Ngaại gì khôgn thử?                                                                       |
                    |       ▒███████▒ When you think about it, why don't try?                                                                   |
                    |       ░▒▒ ▓░▒░▒   Nơi biến polime thành trang phục.                    Order ID: {0, 3}                                      |
                    |       ░░▒ ▒ ░ ▒ Where to turn polymers into clothes.                                                                      |
                    |       ░ ░ ░ ░ ░                                                                                                           |
                    |         ░ ░                                                                                                               |
                    |       ░         [Thời gian: ......................................]                                                       |
                    |                                                                                                                           |
                    |                                                                                                                           |
                    |                 Customer Name   : {1, 20}                                                                    |
                    |                 Phone Number    : {2, 20}                                                                    |
                    |                 Create By Staff : {3, 20}                                                                    |
                    |                                                                                                                           |
                    |                 Address: ......................................                                                           |
                    |                                                                                                                           |
                    |       -------------------------------------------------------------------------------------------------------------       |", order.OrderID, CustomerName, CustomerPhone, NameStaff);
                    Console.Write(@"
                    |       | {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} |       |
                    |       -------------------------------------------------------------------------------------------------------------       |", "No", "Name Clothes", "Quantity", "Unit Price", "Price");
                foreach (OrderDetails item in ListOrderDetail)
                {
                    if (item.Quantity != 0)
                    {
                        maxRow++;
                    }
                }
                count = 1;
                foreach (OrderDetails orderDetails in ListOrderDetail)
                {
                    
                    foreach (Clothes item in listClothes)
                    {
                        if (item.ID == orderDetails.ClothesID)
                        {
                            ClothesName = item.Name;
                            break;
                        }
                    }
                    price = orderDetails.Quantity * orderDetails.UnitPrice;
                    var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                    string stringPrice = String.Format(info, "{0:N0}", price);
                    string stringUnitPrice = String.Format(info, "{0:N0}", orderDetails.UnitPrice);
                    if (orderDetails.Quantity != 0)
                    {
                        if (count == row)
                        {
                            Console.Write(@"
                    |       |");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write(" {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} ", count, ClothesName, orderDetails.Quantity, orderDetails.UnitPrice, price);
                            Console.ResetColor();
                            Console.Write(@"|       |");
                            ID = orderDetails.ClothesID;
                        }else
                        {
                            Console.Write(@"
                    |       | {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} |       |", count, ClothesName, orderDetails.Quantity, orderDetails.UnitPrice, price);
                        }
                        count++;
                    }
                    if (count > maxRow)
                    {
                        break;
                    }
                }
                Console.Write(@"
                    |       -------------------------------------------------------------------------------------------------------------       |");
                Console.Write(@"
                    |                                                                                                                           |
                    =============================================================================================================================
                                {Tab} Back.                                             {Enter} Edit the number of selected clothes.
                                {Delete} Remove select clothes from order.              { 🔽 🔼 } Choice clothes. 
                                {C} Confirm order.                                      {X} Cancel order");
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && row > 1)
                {
                    row--;
                }else if(key.Key == ConsoleKey.DownArrow && row < maxRow)
                {
                    row++;
                }else if (key.Key == ConsoleKey.Enter)
                {
                    foreach (Clothes item in listClothes)
                    {
                        if (item.ID == ID)
                        {
                            foreach (Categories itemCategory in listCategory)
                            {
                                if (itemCategory.ID == item.Category_ID)
                                {
                                    category = itemCategory.Category_name;
                                }
                            }
                            name = item.Name;
                            break;
                        }
                    }
                    foreach (Size_color item in listSzcl)
                    {
                        if (item.clothes_ID == ID)
                        {
                            foreach (Size itemSize in listSize)
                            {
                                if (itemSize.Size_ID == item.Size_ID)
                                {
                                    size = itemSize.Size_Name;
                                    break;
                                }
                            }
                            foreach (Color itemColor in listColor)
                            {
                                if (itemColor.Color_ID == item.Color_ID)
                                {
                                    color = itemColor.Color_Name;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    foreach (OrderDetails item in ListOrderDetail)
                    {
                        if (item.ClothesID == ID)
                        {
                            item.Quantity = UpdateOrderDetail(ListOrderDetail, ID, size, color, category, name);
                        }
                    }
                }else if (key.Key == ConsoleKey.Delete)
                {
                    foreach (OrderDetails item in ListOrderDetail)
                    {
                        if (item.ClothesID == ID)
                        {
                            item.Quantity = 0;
                        }
                    }
                }else if (key.Key == ConsoleKey.Tab)
                {
                    return null;
                }else if (key.Key == ConsoleKey.C)
                {
                    return ListOrderDetail;
                }else if (key.Key == ConsoleKey.X)
                {
                    List<OrderDetails> Cancel = new List<OrderDetails>();
                    return Cancel;
                }


            } while (key.Key != ConsoleKey.Tab);
            return null;
        }
        public int UpdateOrderDetail(List<OrderDetails> ListOrderDetail, int ClothesID, string size, string color, string category, string name)
        {
            int quantity =1;
            int Length =0;
            foreach (OrderDetails orderDetail in ListOrderDetail)
            {
                if (ClothesID == orderDetail.ClothesID)
                {
                    string strOrderID = Convert.ToString(orderDetail.OrderID);
                    string strClothesID = Convert.ToString(orderDetail.ClothesID);
                    quantity = orderDetail.Quantity;
                    int count = 0;
                    string strQuantity = Convert.ToString(quantity);

                    strOrderID = addSpaceToStr(strOrderID, 80);
                    strClothesID = addSpaceToStr(strClothesID, 80);
                    size = addSpaceToStr(size, 80);
                    color = addSpaceToStr(color, 80);
                    category = addSpaceToStr(category, 80);
                    name = addSpaceToStr(name, 80);

                    Length = strQuantity.Length;

                    ConsoleKeyInfo key;

                    do
                    {
                        string strQuantitySpace = addSpaceToStr(strQuantity+"]", 80);
                        Console.Clear();
                        Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                          ----Update order detail----                                                      |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |       =============================================================================================================       |
                    |       |                                                                                                           |       |
                    |       |  ID          : {0}  |       |
                    |       |  Name        : {1}  |       |
                    |       |  Size        : {2}  |       |
                    |       |  Color       : {3}  |       |
                    |       |  Category    : {4}  |       |
                    |       |  Material    : {5}  |       |
                    |       |  Quantity    : {6}  |       |
                    |       |  Price       : {7}  |       |
                    |       |  User Manual : {8}  |       |
                    |       |                                                                                                           |       |  
                    |       =============================================================================================================       |
                    |                                                                                                                           |
                    =============================================================================================================================
",  strOrderID, strClothesID, name, size, color, category, strQuantitySpace);
                        key = Console.ReadKey(true);
                        if (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9 && Length < 80)
                        {
                            strQuantity += key.KeyChar;
                            Length++;
                        }else if (key.Key == ConsoleKey.Backspace && Length > 1)
                        {
                            count = strQuantity.Length;
                            strQuantity = strQuantity.Substring(0, count-1);
                            Length--;
                        }else if (key.Key == ConsoleKey.Backspace && Length <= 1 && Length >= 0)
                        {
                            strQuantity = "";
                        }
                    } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Tab);
                    if (strQuantity == "")
                    {
                        quantity = 1;
                    }else quantity = Convert.ToInt32(strQuantity);
                    
                }
            }
            return quantity;
        }

        public int choiceCategory(List<Categories> listCategory, string staffInfo, string customerInfo)
        {
            int choice = 1, row;
            ConsoleKeyInfo key;
            do
            {
                row = 1;
                Console.Clear();
                Console.Write(@"
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                       ╔═╗┬  ┌─┐┌┬┐┬ ┬┬┌┐┌┌─┐  ╔═╗┬ ┬┌─┐┌─┐                                                |
                    |                                       ║  │  │ │ │ ├─┤│││││ ┬  ╚═╗├─┤│ │├─┘                                                |
                    |                                       ╚═╝┴─┘└─┘ ┴ ┴ ┴┴┘└┘└─┘  ╚═╝┴ ┴└─┘┴                                                  |
                    |                                                                                                                           |
                    =============================================================================================================================
                    |                                                                                                                           |
                    |                                          ----Choice category menu----                                                     |
                    |                 {0, 103}   |
                    |                 {1, 103}   |
                    |                                                                                                                           |
                    =============================================================================================================================", staffInfo, customerInfo);
                    foreach (Categories item in listCategory)
                    {
                        if (choice == row)
                        {
                            Console.Write(@"
                    |  👉  {0}                      |", addSpaceToStr(item.Category_name, 95));
                        }else
                        {
                         Console.Write(@"
                    |    {0}                      |", addSpaceToStr(item.Category_name, 97) );
                        }
                        row++;
                    }
                Console.Write(@"
                    =============================================================================================================================
                     { 🔽 🔼 } Choice.                            {Enter} Confirm.                            {Tab} Back");
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && choice > 1)
                {
                    choice--;
                }else if (key.Key == ConsoleKey.DownArrow && choice < row-1)
                {
                    choice++;
                }else if (key.Key == ConsoleKey.Enter)
                {
                    return choice;
                }
                // else if (key.Key == ConsoleKey.Escape)
                // {
                //     return -1;
                
                // }
                else if (key.Key == ConsoleKey.Tab)
                {
                    return 0;
                }
            } while (key.Key != ConsoleKey.Enter);
            return choice;
        }



    }
}
    
