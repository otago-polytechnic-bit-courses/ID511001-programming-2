using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books;
        private List<Member> members;

        public Library(List<Book> books, List<Member> members)
        {
            this.books = books;
            this.members = members;
        }

        public void SeedData()
        {
            books = new List<Book>
            {
                new Book("To Kill a Mockingbird"),
                new Book("1984"),
                new Book("The Great Gatsby")
            };

            members = new List<Member>
            {
                new Member("Alice", "Walker"),
                new Member("James", "Smith"),
                new Member("Maria", "Gonzalez")
            };
        }

        public List<Book> Books { get => books; set => books = value; }
        public List<Member> Members { get => members; set => members = value; }
    }
}
