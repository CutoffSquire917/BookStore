using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interfaces
{
    public abstract class AbstractBookMenu<T>
    {
        protected int CountOfRanges { get; set; } = 0;

        public delegate Task<IEnumerable<T>> TakeValueMethod(int skip, int take);
        public Func<T, (int, string)> predicate { get; set; } = e => (e.GetHashCode(), e.GetType().Name);
        public int TakeForRange { get; set; } = 10;
        public TakeValueMethod? takeValueMethod { get; set; }
        public (string, string) BackNextMenuItems { get; set; } = ("Back\u140A", "Next\u1405");

        protected List<(int, string)>? GetStringListFromTakeValueMethod()
        {
            var items = takeValueMethod?.Invoke(CountOfRanges * TakeForRange, TakeForRange);
            if (items.Result.Count() == 0) return null;
            var menuItems = items.Result.Select(predicate).ToList();
            menuItems.Add((0, BackNextMenuItems.Item1));
            menuItems.Add((0, BackNextMenuItems.Item2));
            menuItems.Add((0, "Add\u2795"));
            return menuItems;
        }

        public (int? Id, string? MenuItem)? BookMenuRun()
        {
            if (takeValueMethod == null) return null;
            var menuItems = GetStringListFromTakeValueMethod();
            while (true)
            {
                var resultOfEnter = MyConsole.ListMenuToConsole(menuItems.Select(e => e.Item2).ToList(), $"\n\t\u2261Page {CountOfRanges + 1}\u2261\n");

                if (resultOfEnter.Value.MenuItem == BackNextMenuItems.Item1)
                {
                    if (CountOfRanges != 0)
                    {
                        CountOfRanges--;
                        menuItems = GetStringListFromTakeValueMethod();
                    }
                }
                else if (resultOfEnter.Value.MenuItem == BackNextMenuItems.Item2)
                {
                    CountOfRanges++;
                    var tempMenuItems = GetStringListFromTakeValueMethod();
                    if (tempMenuItems != null)
                        menuItems = tempMenuItems;
                    else
                        CountOfRanges--;
                }
                else if (resultOfEnter.Value.MenuItem == "Add\u2795")
                {
                    return (null, "Add");
                }
                else if (resultOfEnter.Value.MenuItem == "Exit")
                {
                    return (null, "Exit");
                }
                else
                {
                    return (menuItems[resultOfEnter.Value.Id].Item1, menuItems[resultOfEnter.Value.Id].Item2);
                }
            }
        }

    }
}
