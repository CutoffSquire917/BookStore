using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.Servis.BookStoreService;

namespace BookStore.Service.Interfaces
{
    public interface IPage
    {
        event PageFinishedHandler? PageFinished;

        void RunPage();
    }
}
