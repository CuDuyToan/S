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
        public void Title(string title1)
        {
            Line();
            System.Console.WriteLine(" " + title1);
            Line();
        }
        public void Line(){
            System.Console.WriteLine("=======================================================================================================");
        }
        public void PressAnyKeyToContinue(){
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
    
