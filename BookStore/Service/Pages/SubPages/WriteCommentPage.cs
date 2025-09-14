using BookStore.Models;
using BookStore.Repositories;
using BookStore.Service.Interfaces;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Pages.SubPages
{
    public class WriteCommentPage : AbstractAddingForm
    {

        public void Writing(Book book)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\n\t{book.Title} + comment\n\n UserName: ");
            Console.Write($"\n\t{book.Title} + comment\n\n UserName: ");
            string userName = Console.ReadLine();
            sb.Append(userName + "\n");

            sb.Append("\n Email: ");
            Console.Write("\n Email: ");
            string email = Console.ReadLine();
            sb.Append(email + "\n");

            sb.Append("\n Comment: ");
            Console.Write("\n Comment: ");
            string comment = Console.ReadLine();
            sb.Append(comment + "\n");

            sb.Append("\n Stars: ");
            Console.Write("\n Stars: ");
            string stringStars = Console.ReadLine();
            if (!byte.TryParse(stringStars, out byte stars))
            {
                stars = 5;
            }
            sb.Append(stringStars + "\n");
            
            var resultFromForm = MyConsole.ListMenuToConsole(new List<string>
            {
                "Send"
            }, sb.ToString());
            if (resultFromForm.Value.MenuItem == "Send")
            {
                if (userName != null && email != null && comment != null)
                {
                    var task = new ReviewRepository().AddReviewAsync(new Review
                    {
                        UserName = userName,
                        UserEmail = email,
                        Comment = comment,
                        Stars = stars,
                        Book = book
                    });
                }

            }
        }
    }
}
