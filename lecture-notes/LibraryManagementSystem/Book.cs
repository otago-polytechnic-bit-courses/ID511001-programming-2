using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {
        private string title;

        public Book(string title)
        {
            this.title = title;
        }

        public string Title { get => title; set => title = value; }
    }
}
