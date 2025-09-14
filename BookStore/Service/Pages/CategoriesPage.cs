using BookStore.Repositories;
using BookStore.Service.Interfaces;
using BookStore.Servis;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Pages
{
    public class CategoriesPage : IPage
    {
        public event BookStoreService.PageFinishedHandler? PageFinished;

        public void RunPage()
        {
            var categoryRepository = new CategoryRepository();
            var listOfCategories = categoryRepository.GetAllCategoriesAsync().Result.Select(e => e.Name).ToList();
            listOfCategories.Add("Add category");
            (int Id, string? MenuItem)? resultFromMenu;
            while (true)
            {
                resultFromMenu = MyConsole.ListMenuToConsole(listOfCategories, $"\n\tCategories\n");
                if (resultFromMenu != null && resultFromMenu.Value.MenuItem == "Add category")
                {
                    Console.Clear();
                    StringBuilder sb = new StringBuilder();

                    Console.Write($"\n\tCategories\n");
                    sb.Append($"\n\tCategories\n");

                    sb.Append("\nName of category: ");
                    Console.Write("\nName of category: ");
                    string name = Console.ReadLine();
                    sb.Append(name);

                    sb.Append("\n\nDescription: ");
                    Console.Write("\nDescription: ");
                    string description = Console.ReadLine();
                    sb.Append(description + "\n");

                    var resultFromAddingMenu = MyConsole.ListMenuToConsole(new List<string> { "Confirm" }, sb.ToString());

                    if (resultFromAddingMenu != null && resultFromAddingMenu.Value.MenuItem == "Confirm" && name != null && description != null)
                    {
                        _ = categoryRepository.AddCategoryAsync(new Models.Category
                        {
                            Name = name,
                            Description = description
                        });
                        listOfCategories.Clear();
                        listOfCategories = categoryRepository.GetAllCategoriesAsync().Result.Select(e => e.Name).ToList();
                        listOfCategories.Add("Add category");
                    }
                }
                else if (resultFromMenu != null && resultFromMenu.Value.MenuItem == "Exit")
                {
                    break;
                }

            }
            PageFinished?.Invoke(null);
        }
    }
}
