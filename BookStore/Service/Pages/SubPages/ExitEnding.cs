using BookStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.Servis.BookStoreService;

namespace BookStore.Service.Pages.SubPages
{
    public class ExitEnding : IPage
    {
        public event PageFinishedHandler? PageFinished;

        public void RunPage()
        {
            var circle = new[] { "/", "\u2014", "\\", "|" };
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 2; i++)
            {
                foreach (var c in circle)
                {
                    Console.Clear();
                    Console.WriteLine("\n\tEnding... " + c);
                    Thread.Sleep(500);
                }
            }
            Console.ResetColor();
            Console.Clear();
        }
    }
}
