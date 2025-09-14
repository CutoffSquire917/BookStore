namespace BookStore;
using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Repositories;
using BookStore.Servis;
using ConsoleApplication;
  
class Program
{
    public static ApplicationContext DbContext() => new ApplicationContextFactory().CreateDbContext();

    public static IBook _books;

    static void Initialize()
    {
        new DbInit().Init(DbContext());
        _books = new BookRepository();
    }


    static async Task Main(string[] args)
    {
        //using (ApplicationContext db = DbContext())
        //{
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();
        //}
        Initialize();
        BookStoreService bookStoreService = new BookStoreService();
        while (true)
        {
            bookStoreService.Run();
            if (bookStoreService.IsEnd) break;
        }
    }

}