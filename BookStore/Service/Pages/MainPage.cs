using BookStore.Service.Interfaces;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.Servis.BookStoreService;

namespace BookStore.Service.Pages
{
    public class MainPage : IPage
    {
        public event PageFinishedHandler? PageFinished;

        public List<(IPage, string)>? MenuItems { get; set; }
        
        public void SetPages(List<IPage>? pages, List<string?>? items = null)
        {
            if (pages == null) throw new ArgumentNullException(nameof(pages));

            var tempMenuItems = new List<(IPage, string)>();
            if (items == null)
            {
                foreach (var page in pages)
                {
                    tempMenuItems.Add((page, page.GetType().Name));
                }
            }
            else
            {
                for (int i = 0; i < pages.Count(); i++)
                {
                    if (items[i] is null)
                        tempMenuItems.Add((pages[i], pages[i].GetType().Name));
                    else
                        tempMenuItems.Add((pages[i], items[i]));
                }
            }
            MenuItems = tempMenuItems;
        }
        public void RunPage()
        {
            if (MenuItems == null) return;
            var key = MyConsole.ListMenuToConsole(MenuItems.Select(e => e.Item2).ToList(), "\n\t╔════════════════╗\n\t║   Book Store   ║\n\t╚════════════════╝\n");
            if (key.Value.MenuItem == "Exit")
                PageFinished?.Invoke(new SubPages.ExitEnding());
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\tLoading...");
                Console.ResetColor();
                
                PageFinished?.Invoke(MenuItems.FirstOrDefault(e => e.Item2 == key.Value.MenuItem).Item1);
            }
        }
    }
}
