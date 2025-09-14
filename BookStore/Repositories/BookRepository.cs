using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class BookRepository : IBook
    {
        public async Task AddOrderLineAsync(int id, int orderId, int quantity)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                var order = await context.Orders
                            .Include(o => o.Lines)
                            .FirstOrDefaultAsync(o => o.Id == orderId);
                var book = await context.Books.FirstOrDefaultAsync(e => e.Id == id);
                if (book == null)
                    return;
                var orderLine = order.Lines.FirstOrDefault(e => e.OrderId == order.Id && e.BookId == book.Id);
                if (orderLine != null)
                {
                    orderLine.Quantity += quantity;
                }
                else
                {
                    order.Lines.Add(new OrderLine { BookId = book.Id, OrderId = order.Id, Quantity = quantity });
                    context.Update(order);
                }
                await context.SaveChangesAsync();
            }
        }
        public async Task AddBookAsync(Book book)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(Book book)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditBookAsync(Book book)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                var currentBook = context.Books
                    .Include(b => b.Authors)
                    .FirstOrDefault(b => b.Id == book.Id);

                if (currentBook is null) return;

                // Копируем простые свойства книги
                context.Entry(currentBook).CurrentValues.SetValues(book);

                // Получаем list ID авторов из book
                var incomingAuthorIds = book.Authors.Select(a => a.Id).ToList();

                // Загружаем авторов из базы по этим ID, чтобы избежать конфликта трекинга
                var updatedAuthors = context.Authors
                    .Where(a => incomingAuthorIds.Contains(a.Id))
                    .ToList();

                // Удаляем старых авторов, которых больше нет в обновлённом списке
                currentBook.Authors = currentBook.Authors.Where(a => !incomingAuthorIds.Contains(a.Id)).ToList();

                // Добавляем новых авторов, которых еще нет в currentBook.Authors
                foreach (var author in updatedAuthors)
                {
                    if (!currentBook.Authors.Any(a => a.Id == author.Id))
                    {
                        currentBook.Authors.Add(author);
                    }
                }
                context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.ToListAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksWithAuthorsAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Authors).ToListAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByCountAsync(int skip, int take)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<Book> GetBookAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByNameAsync(string name)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Where(e => e.Title.Contains(name)).ToListAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Author author)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Where(e => e.Authors.Any(e => e.Id == author.Id)).ToListAsync();
            }
        }

        public async Task<Book> GetBookWithAuthorsAndReviewAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Authors).Include(e => e.Reviews).FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<Book> GetBookWithAuthorsAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Authors).FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<Book> GetBookWithCategoryAndAuthorsAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Category).Include(e => e.Authors).FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<Book> GetBookWithPromotionAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Promotion).FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<Book> GetBooksWithAuthorsAndReviewAndCategoryAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Category).Include(e => e.Authors).Include(e => e.Reviews).FirstOrDefaultAsync(e => e.Id == id);
            }
        }
        public async Task<Book> GetBooksWithAllAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Books.Include(e => e.Category).Include(e => e.Authors).Include(e => e.Reviews).Include(e => e.Promotion).FirstOrDefaultAsync(e => e.Id == id);
            }
        }
    }
}
