using BookStore.Models;
using BookStore.Repositories;
using BookStore.Service.Interfaces;
using BookStore.Service.Pages.SubPages;
using BookStore.Servis;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Pages
{
    public class BooksPage : AbstractBookMenu<Book>, IPage
    {
        public event BookStoreService.PageFinishedHandler? PageFinished;
        public Book? CurrentBook { get; set; }

        public void RunPage()
        {
            var bookRepository = new BookRepository();
            takeValueMethod += bookRepository.GetBooksByCountAsync;
            predicate = e => (e.Id, e.Title);
            (int? Id, string? MenuItem)? resultFromMenu;
            while (true)
            {
                resultFromMenu = BookMenuRun();
                if (resultFromMenu == null)
                {
                    continue;
                }
                else if (resultFromMenu.Value.Id > 0 && resultFromMenu.Value.Id < 10)
                {
                    CurrentBook = bookRepository.GetBooksWithAllAsync(resultFromMenu.Value.Id.Value).Result;
                    ViewBook(CurrentBook);
                }
                else if (resultFromMenu.Value.MenuItem == "Add")
                {
                    AddBookPage addBookPage = new AddBookPage();
                }
                else if (resultFromMenu.Value.MenuItem == "Exit")
                {
                    break;
                }
            }
            PageFinished?.Invoke(null);
        }


        public void ViewBook(Book book)
        {
            StringBuilder stringBuilder;
            while (true)
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Append($"\n \u2727 Authors: {string.Join(", ", book.Authors.Select(e => e.Name))}");
                stringBuilder.Append($"\n \u2727 Category: {book.Category.Name}");
                stringBuilder.Append($"\n \u2727 Publicshed on: {book.PublishedOn.ToShortDateString()}");
                stringBuilder.Append($"\n \u2727 Publisher: {book.Publisher}");
                stringBuilder.Append($"\n \u2727 Price: {book.Price} {(book.Promotion.Amount != null ? $"({book.Promotion.Amount} sale)" : "")}");
                stringBuilder.Append($"\n Description: {book.Description}");
                stringBuilder.Append($"\n Reviews:{string.Join("", book.Reviews.Select(e => $"\n  \u25C9 {e.UserName} ({e.Stars}/10)\n    - {e.Comment}"))}\n");

                var resultFromBook = MyConsole.ListMenuToConsole(new List<string>
                        {
                            "Write a comment"
                        }, $"\n\t{book.Title}\n", stringBuilder.ToString());
                if (resultFromBook.Value.MenuItem == "Write a comment")
                {
                    WriteCommentPage writeCommentPage = new WriteCommentPage();
                    writeCommentPage.Writing(book);
                }
                else
                    break;
                stringBuilder.Clear();
            }
        }

    }
}
