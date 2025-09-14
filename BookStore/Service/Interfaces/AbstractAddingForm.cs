using BookStore.Repositories;
using BookStore.Servis;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interfaces
{
    public class AbstractAddingForm
    {
        public StringBuilder StringBuilder { get; set; } = new StringBuilder();

        public void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(title);
            Console.ResetColor();
            StringBuilder.Append(title);
        }
        public string AskInput(string label)
        {
            Console.Write(label);
            string? input = Console.ReadLine();
            StringBuilder.AppendLine(label + input + "\n");
            return input == null ? string.Empty : input.ToString();
        }
       
        public bool Confirm()
        {
            if (MyConsole.ListMenuToConsole(new List<string> { "Confirm" }, StringBuilder.ToString()).Value.MenuItem == "Confirm")
            {
                StringBuilder.Clear();
                return true;
            }
            else
            {
                StringBuilder.Clear();
                return false;
            }
        }
        
    }
}
