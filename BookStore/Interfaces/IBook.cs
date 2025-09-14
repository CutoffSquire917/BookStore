using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Interfaces
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetAllBooksWithAuthorsAsync();

        Task<Book>? GetBookAsync(int id);
        Task<IEnumerable<Book>> GetBooksByNameAsync(string name);
        Task<IEnumerable<Book>> GetBooksByCountAsync(int skip, int take);
        Task<Book> GetBookWithPromotionAsync(int id);
        Task<Book> GetBookWithAuthorsAsync(int id);
        Task<Book> GetBookWithCategoryAndAuthorsAsync(int id);
        Task<Book> GetBookWithAuthorsAndReviewAsync(int id);
        Task<Book> GetBooksWithAuthorsAndReviewAndCategoryAsync(int id);
        Task<Book> GetBooksWithAllAsync(int id);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(Author author);

        Task AddOrderLineAsync(int id, int orderId, int quantity);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task EditBookAsync(Book book);

    }
}
