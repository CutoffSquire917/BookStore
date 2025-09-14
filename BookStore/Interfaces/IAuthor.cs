using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Interfaces
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorWithBooksAsync(int id);
        Task<Author> GetAuthorAsync(int id);
        Task<IEnumerable<Author>> GetAuthorsByNameAsync(string name);
        Task<IEnumerable<Author>> GetAuthorsByCountAsync(int skip, int take);

        Task AddAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
        Task EditAuthorAsync(Author author);
    }
}
