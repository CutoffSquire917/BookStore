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
    public class OrdersPage : AbstractBookMenu<Order>, IPage
    {
        public event BookStoreService.PageFinishedHandler? PageFinished;
        public Order? CurrentOrder { get; set; }

        public void RunPage()
        {
            var orderRepository = new OrderRepository();
            takeValueMethod += orderRepository.GetOrdersByCountAsync;
            predicate = e => (e.Id, (e.CustomerName + " - " + e.Address));
            (int? Id, string? MenuItem)? resultFromMenu;
            while (true)
            {
                resultFromMenu = BookMenuRun();
                if (resultFromMenu == null)
                {
                    continue;
                }
                else if (resultFromMenu.Value.Id != null)
                {
                    CurrentOrder = orderRepository.GetOrderWithOrderLinesAndBooksAsync(resultFromMenu.Value.Id.Value).Result;
                    ViewOrder(CurrentOrder);
                }
                else if (resultFromMenu.Value.MenuItem == "Exit")
                {
                    break;
                }
            }
            PageFinished?.Invoke(null);
        }


        public void ViewOrder(Order order)
        {
            StringBuilder stringBuilder;
            while (true)
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Append($"\n \u2727 Customer name: {order.CustomerName}");
                stringBuilder.Append($"\n \u2727 Address: {order.City}, {order.Address}");
                stringBuilder.Append($"\n \u2727 City: {order.City}");
                stringBuilder.Append($"\n \u2727 Ordered: {order.Shipped} ({order.Lines.Count})");
                if (order.Lines.Count > 0)
                    stringBuilder.Append($"\n{string.Join("\n", order.Lines.Select(e => $"  \u2610 {e.Book.Title} (count {e.Quantity})"))}");
                stringBuilder.Append("\n");

                var resultFromBook = MyConsole.ListMenuToConsole(new List<string>
                        {
                            "Create order"
                        }, $"\n\tOrder - {order.Id}\n", stringBuilder.ToString());
                if (resultFromBook.Value.MenuItem == "Create order")
                {
                    CreateOrderLinePage createOrderLinePage = new CreateOrderLinePage();
                    createOrderLinePage.CreateOrderLine(CurrentOrder);
                }
                else
                    break;
                stringBuilder.Clear();
            }
        }



    }

}
