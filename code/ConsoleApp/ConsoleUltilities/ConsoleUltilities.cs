using Persistence;

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
            int choice;
            do
            {
                Console.Clear();
                if(title1 != null)
                    Title(title1, str1);
                for (int i=0; i < menuItem.Count(); i++)
                {
                    System.Console.WriteLine("" + (i+1) + ". " + menuItem[i]);
                }
                Line();
                System.Console.Write("Your choice: ");
                int.TryParse(System.Console.ReadLine(), out choice);
            }while (choice <= 0 || choice > menuItem.Count());
            return choice;
        }

        public int MenuHandle(string title1, string[] menuItem, string str1, string str2)//show menu with information two object
        {
            int choice;
            do
            {
                Console.Clear();
                if(title1 != null)
                    Title(title1, str1, str2);
                for (int i=0; i < menuItem.Count(); i++)
                {
                    System.Console.WriteLine("" + (i+1) + ". " + menuItem[i]);
                }
                Line();
                System.Console.Write("Your choice: ");
                int.TryParse(System.Console.ReadLine(), out choice);
            }while (choice <= 0 || choice > menuItem.Count());
            return choice;
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
            System.Console.WriteLine(" " + title1 + "\n" + str1);
            Line();
        }

        public void Title(string title1, string str1, string str2)//title on menu with info of obj
        {
            Line();
            System.Console.WriteLine(" " + title1 + "\n" + str1 + "                           " + str2);
            Line();
        }
        public void Line(){
            System.Console.WriteLine("================================================================================================================================");
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
                }else if(key.Key == ConsoleKey.Escape){
                    return "EXIT";
                }else if(key.Key == ConsoleKey.Backspace){
                    return "RE-ENTER";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Backspace);
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
                }else if(key.Key == ConsoleKey.Escape){
                    return "EXIT";
                }else if(key.Key == ConsoleKey.Backspace){
                    return "RE-ENTER";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            Console.WriteLine("");
            return str;
        }

        public string pressEnterEsc(string text)
        {
            string PressKey = "Esc";
            ConsoleKeyInfo key;
            Console.WriteLine(text);
            key = Console.ReadKey(true);
            do
            {
                if(key.Key!= ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
                {
                    Console.Clear();
                    Line();
                    Console.WriteLine(text);
                    Console.WriteLine("[!]Can only press [Esc] or [Enter].");
                    key = Console.ReadKey(true);
                }
            } while (key.Key!= ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.Enter)PressKey = "Enter";
            return PressKey;
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
                }else if(key.Key == ConsoleKey.Escape){
                    return "EXIT";
                }else if(key.Key == ConsoleKey.Backspace){
                    return "RE-ENTER";
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
                Line();
                Title(title, str1, str2);
                Console.WriteLine("  | {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12}     |", "No", "Clothes Name", "Color", "Size", "Category", "Unit Price");
                Line();
                int count =0;
                foreach (rowPageSpl item in ListRowPage)
                {
                    if(item.No>=10*page+1 && item.No<=(10*page+11))
                    {
                    var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                    string price = String.Format(info, "{0:N0}", item.Unit_price);
                        if (item.No == No)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("<<| {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12} vnđ |>>", item.No, item.Name, item.Color, item.Size, item.Category, price);
                            Console.ResetColor();
                        }else
                        {
                            Console.WriteLine("  | {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12} vnđ |  ", item.No, item.Name, item.Color, item.Size, item.Category, price);
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
                        Console.WriteLine("  | {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12}     |  ", "", "", "", "", "", "");
                        count2++;
                    }
                }
                Line();
                Console.WriteLine("{0,61}[{1}/{2}]", " ", page+1, maxpage+1);
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
                }else if(key.Key == ConsoleKey.Escape)
                {
                    No=0;
                    break;
                }


            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
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
                }else if(key.Key == ConsoleKey.Escape){
                    return "EXIT";
                }else if(key.Key == ConsoleKey.Backspace){
                    Console.Clear();
                    Console.WriteLine(text);
                    number = "";
                }
                else
                {
                    Console.Write("");
                }
            }while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            if(number == "")number="1";
            return number;
        }

        public Staff LoginMenu(List<Staff> listStaff)
        {
            Staff staff = new Staff();
            staff.UserName = "";
            staff.Password = "";
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
                    =============================================================================================================================
", addSpaceToStr("["+username+"]", 82), addSpaceToStr("["+password+"]", 82));                              
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
                }else if (key.Key == ConsoleKey.Backspace && row == 1)
                {
                    int delete = staff.UserName.Length-1;
                    staff.UserName = staff.UserName.Substring(0, delete);
                }else if (((key.Key >= ConsoleKey.A && key.Key <= ConsoleKey.Z) || (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9)) && row == 2)
                {
                    staff.Password += key.KeyChar;
                }else if (key.Key == ConsoleKey.Backspace && row == 1)
                {
                    int delete = staff.Password.Length-1;
                    staff.Password = staff.Password.Substring(0, delete);
                }
                else if (key.Key == ConsoleKey.Enter && row == 2)
                {
                    foreach (Staff item in listStaff)
                    {
                        if (staff.UserName == item.UserName && staff.Password == item.Password)
                        {
                            return item;
                        }
                    }
                    report = "[!]{username} or {password} incorrect.";
                }
                else if (key.Key == ConsoleKey.Enter && row ==1)
                {
                    row++;
                }
                if (row == 1)
                {
                    username = staff.UserName + "_";
                }else if (row == 2)
                {
                    password = hideWord(staff.Password)+"_";
                }
            } while (key.Key != ConsoleKey.Escape);

            return staff;
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
            for (int i = 0; i < word.Length-1; i++)
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
    }
}
    
