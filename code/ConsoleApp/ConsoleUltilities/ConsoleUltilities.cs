using Persistence;

namespace CS
{
    public class Ultilities
    {
        public int MenuHandle(string title1, string[] menuItem)
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

        public int MenuHandle(string title1, string[] menuItem, string str1, string str2)
        {
            int i = 0, choice;
            if(title1 != null)
                Title(title1, str1, str2);
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
        public void Title(string title1)
        {
            Line();
            System.Console.WriteLine(" " + title1);
            Line();
        }

        public void Title(string title1, string str1, string str2)
        {
            Line();
            System.Console.WriteLine(" " + title1 + "\n[" + str1 + " | " + str2 + "]");
            Line();
        }
        public void Line(){
            System.Console.WriteLine("================================================================================================================================");
        }
        public void PressAnyKeyToContinue(){
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
        public string hidePassword()
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
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine(text);
                    Console.Clear();
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
    }
}
    
