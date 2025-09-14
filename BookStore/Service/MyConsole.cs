using System.Data;
using System.Text;

namespace ConsoleApplication
{
    public class MyConsole
    {
        static MyConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static string MenuPointer { get; set; } = " ";
        public static string TheLastItem { get; set; } = "Exit";

        public static (int Id, string? MenuItem)? ListMenuToConsole(List<string> menuListItems, string? title = null, string? subtitle = null)
        {
            Console.CursorVisible = false;
            int Index = 0;
            var menuItems = new List<string>(menuListItems);
            menuItems.Add(TheLastItem);
            var ItemsCount = menuItems.Count;
            (int Id, string? MenuItem)? tempResult;
            while (true)
            {
                ClearConsole();
                if (title is not null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(title);
                    Console.ResetColor();
                }

                if (subtitle is not null)
                    Console.WriteLine(subtitle);

                for (int i = 0; i < ItemsCount; i++)
                {
                    if (i + 1 == ItemsCount && i == Index)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\u2022 {menuItems[i]} {MenuPointer}");
                        Console.ResetColor();
                        continue;
                    }
                    else if (i == Index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"\u2022 {menuItems[i]}{MenuPointer}");
                        Console.ResetColor();
                        continue;
                    }
                    
                    Console.WriteLine("\u2022 " + menuItems[i]);
                }
                

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("(use \u2B05 \u2B07\u2B06\u2B95 )");
                Console.ResetColor();

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (Index <= 0)
                        Index = ItemsCount - 1;
                    else
                        Index--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (Index >= ItemsCount - 1)
                        Index = 0;
                    else
                        Index++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    tempResult = (Index, menuItems[Index]);
                    ClearConsole();
                    break;
                }
            }
            Console.CursorVisible = true;
            TheLastItem = "Exit";
            return tempResult;
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
