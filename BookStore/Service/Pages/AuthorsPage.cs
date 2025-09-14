using BookStore.Interfaces;
using BookStore.Models;
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
    public class AuthorsPage : AbstractBookMenu<Author>, IPage
    {
        public event BookStoreService.PageFinishedHandler? PageFinished;
        public Author? Author { get; set; }

        public void RunPage()
        {
            var authorRepository = new AuthorRepository();
            takeValueMethod += authorRepository.GetAuthorsByCountAsync;
            predicate = e => (e.Id, e.Name);
            (int? Id, string? MenuItem)? resultFromMenu;
            while (true)
            {
                resultFromMenu = BookMenuRun();
                if (resultFromMenu == null)
                    continue;
                else if (resultFromMenu.Value.Id != null)
                {
                    Author = authorRepository.GetAuthorWithBooksAsync(resultFromMenu.Value.Id.Value).Result;
                    if (Author is null)
                        Console.WriteLine("\n\n\tERROR\n\n");
                    else
                        ViewAuthor(Author);
                }
                else if (resultFromMenu.Value.MenuItem == "Exit")
                    break;
            }
            PageFinished?.Invoke(null);
        }

        public void ViewAuthor(Author author)
        {
            var bookRepository = new BookRepository();
            List<Book> books;
            (int Id, string? MenuItem)? resultFromAuthorsMenu;
            while (true)
            {
                books = bookRepository.GetBooksByAuthorAsync(Author).Result.ToList();
                resultFromAuthorsMenu = MyConsole.ListMenuToConsole(books.Select(e => $"{e.Title} ({e.PublishedOn.ToShortDateString()})").ToList(), $"\n\t{Author.Name} ({Author.Books.Count})\n");

                if (resultFromAuthorsMenu != null && books.Select(e => $"{e.Title} ({e.PublishedOn.ToShortDateString()})").Any(e => e == resultFromAuthorsMenu.Value.MenuItem))
                {
                    var bookPage = new BooksPage();
                    bookPage.ViewBook(Task.FromResult(bookRepository.GetBooksWithAllAsync(books[resultFromAuthorsMenu.Value.Id].Id).Result).Result);
                }
                else if (resultFromAuthorsMenu != null && resultFromAuthorsMenu.Value.MenuItem == "Exit")
                    break;
                
            }
        }

    }
}
