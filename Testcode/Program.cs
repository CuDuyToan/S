using System.Timers;

// string dateTime = dateTime.Now.ToString();
int orderID =123;
string CustomerName = "toan", CustomerPhone = "0123456789", NameStaff = "cu duy toan";

Console.Write(@"
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
                        |       -------------------------------------------------------------------------------------------------------------       |", orderID, CustomerName, CustomerPhone, NameStaff);
                        Console.Write(@"
                        |       | {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} |       |", "No", "Name Clothes", "Quantity", "Unit Price", "Price");
                        Console.Write(@"
                        |       |");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write(" {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} ", "No", "Name Clothes", "Quantity", "Unit Price", "Price");
                        Console.ResetColor();
                        Console.Write(@"|       |
                        |       -------------------------------------------------------------------------------------------------------------       |");
