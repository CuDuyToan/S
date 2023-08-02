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
        public rowPageSpl GetListClothesByCategory(List<Clothes> ListClothes, List<Size_color> List_szcl, List<Size> ListSize, List<Color> ListColor, List<Categories> ListCategory, int page, int row, string category)
        {
            Clothes clothes = new Clothes();
            List<rowPageSpl> rowPageSpls = new List<rowPageSpl>();
            rowPageSpl rowpag = new rowPageSpl();
            string nameColor = "", nameSize = "";
            int count = 1;
            int category_ID;
            foreach (Categories item in ListCategory)
            {
                if (item.Category_name == category)
                {
                    category_ID = item.ID;
                    foreach (Clothes item_clothes in ListClothes)
                    {
                        if (item_clothes.Category_ID == category_ID)
                        {
                            foreach (Size_color item_szcl in List_szcl)
                            {
                                if (item_szcl.clothes_ID == item_clothes.ID)
                                {
                                    foreach (Size item_size in ListSize)
                                    {
                                        if (item_size.Size_ID == item_szcl.Size_ID)
                                        {
                                            nameSize = item_size.Size_Name;
                                            break;
                                        }
                                    }
                                    foreach (Color item_color in ListColor)
                                    {
                                        if (item_color.Color_ID == item_szcl.Color_ID)
                                        {
                                            nameColor = item_color.Color_Name;
                                        }
                                    }
                                    break;
                                }
                            }
                            rowpag = updatePageSpl(count, item.ID, item_clothes.Name, nameSize, nameColor, item_clothes.Unit_price, category);
                            rowPageSpls.Add(rowpag);
                            count++;
                            break;
                        }
                    }
                    break;
                }
            }
            return rowpag;
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
                rowpag = GetListClothesByCategory(ListClothes, List_szcl, ListSize,ListColor, ListCategory, page, row, conditionStr);
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
                Console.WriteLine("  | {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12}    |", "No", "Clothes Name", "Color", "Size", "Category", "Unit Price");
                Line();
                int count =0;
                foreach (rowPageSpl item in ListRowPage)
                {
                    if(item.No>=10*page+1 && item.No<=(10*page+11))
                    {
                        if (item.No == No)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("<<| {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12} VNĐ |>>", item.No, item.Name, item.Color, item.Size, item.Category, item.Unit_price);
                            Console.ResetColor();
                        }else
                        {
                            Console.WriteLine("  | {0,4} | {1,50} | {2,10} | {3,4} | {4,20} | {5,12} VNĐ |  ", item.No, item.Name, item.Color, item.Size, item.Category, item.Unit_price);
                        }
                        count++;
                        if (count == 10)
                        {
                            break;
                        }
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
    }
}
    
