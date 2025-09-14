using BookStore.Service.Interfaces;
using BookStore.Service.Pages;
using BookStore.Service.Pages.SubPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Servis
{
    public class BookStoreService
    {
        public delegate void PageFinishedHandler(IPage? newPage);

        public List<(IPage, string?)> Pages { get; set; }
        private IPage CurrentPage { get; set; } = null!;
        private MainPage _mainPage { get; set; } = null!;

        public bool IsEnd { get; set; } = false;

        public BookStoreService() {
            Pages = new List<(IPage, string?)>
            {
                (new AuthorsPage(), "Authors"),
                (new BooksPage(), "Books"),
                (new OrdersPage(), "Orders"),
                (new CategoriesPage(), "Categories"),
            };
            
            foreach (var page in Pages.Select(e => e.Item1))
            {
                page.PageFinished += SetNewPage;
            }
            _mainPage = new MainPage();
            _mainPage.SetPages(Pages.Select(e => e.Item1).ToList(), Pages.Select(e => e.Item2).ToList());
            _mainPage.PageFinished += SetNewPage;
            SetNewPage(_mainPage);
        }

        public void SetNewPage(IPage? _newPage)
        {
            if (_newPage == null)
            {
                CurrentPage = _mainPage;
                return;
            }
            else if (_newPage.GetType() == typeof(ExitEnding)) {
                _newPage.RunPage();
                IsEnd = true;
                return;
            }
            CurrentPage = _newPage;
        
        }
        public IPage GetCurrentPage() => CurrentPage;
        
        public void Run()
        {
            CurrentPage.RunPage();
        }
    }
}
