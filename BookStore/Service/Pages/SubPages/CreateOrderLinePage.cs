using BookStore.Repositories;
using BookStore.Service.Interfaces;
using BookStore.Servis;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Pages.SubPages
{
    public class CreateOrderLinePage : AbstractAddingForm
    {

        public void CreateOrderLine(Models.Order order) {
            PrintTitle("\n\tCreating order line\n\n");
            BookRepository bookRepository = new BookRepository();


            Models.Book? book = bookRepository.GetBooksByNameAsync(AskInput("Enter name of the book: ")).Result.FirstOrDefault();
            Console.WriteLine();
            var quantityString = AskInput("Enter quantity: ");
            if (book != null && int.TryParse(quantityString, out int quantity) && Confirm())
            {
                _ = bookRepository.AddOrderLineAsync(book.Id, order.Id, quantity);
            }

        }
    }
}
