using BookStore.Repositories;
using BookStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Pages.SubPages
{
    public class AddBookPage : AbstractAddingForm
    {
        public void AddBook(Models.Book book)
        {
            PrintTitle("\n\tAdding book\n\n");
            BookRepository bookRepository = new BookRepository();


            //Models.Book? book = bookRepository.GetBooksByNameAsync(AskInput("Enter name of the book: ")).Result.FirstOrDefault();
            //Console.WriteLine();
            //var quantityString = AskInput("Enter quantity: ");
            //if (book != null && int.TryParse(quantityString, out int quantity) && Confirm())
            //{
            //    _ = bookRepository.AddOrderLineAsync(book.Id, order.Id, quantity);
            //}

        }

    }
}
