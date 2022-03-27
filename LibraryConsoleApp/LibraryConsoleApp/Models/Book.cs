using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Book
    {
        private static int _idCounter;
        private static Book[] _allBooks;

        public int BookId { get; private set; }
        public string Name { get; set; }
        public Person Author { get; set; }
        public int PublishYear { get; set; }

        public static Book[] AllBooks { get { return _allBooks; } }

        static Book()
        {
            _idCounter = 0;
            _allBooks = new Book[0];
        }

        private Book()
        {
            BookId = ++_idCounter;
            Array.Resize(ref _allBooks, _allBooks.Length + 1);
            _allBooks[^1] = this;
        }

        public Book(string name, Person person, int publishYear) : this()
        {
            Name = name;
            Author = person;
            PublishYear = publishYear;
        }

        public static void PrintAllBooks()
        {
            if(_allBooks.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                  "------------ There are no books -----------\n" +
                                  "-------------------------------------------");
            }
            else
            {
                Console.WriteLine("-------------------------------------------\n" +
                              "----------------- All books ---------------\n" +
                              "-------------------------------------------");
                foreach (Book book in _allBooks)
                {

                    Console.WriteLine($"Id : {book.BookId} {book.Name} Book author : {book.Author.Name} {book.Author.Surname} Publish year : {book.PublishYear}");

                }
                Console.WriteLine("-------------------------------------------\n");
            }
        }

        public static Person CreateAuthorByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                              "------------ Author information -----------\n" +
                              "-------------------------------------------");

            string name = Program.GetStringInputByConsole("author's name");
            string surname = Program.GetStringInputByConsole("author's surname");

            Console.WriteLine("-------------------------------------------\n" +
                              "------- Author created successfully! ------\n" +
                              "-------------------------------------------");
            return _ = new Person(name, surname);
        }

        public static void CreateBookByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                              "------------- Create new book -------------\n" +
                              "-------------------------------------------");

            string bookName = Program.GetStringInputByConsole("name of book");

            Person bookAuthor = CreateAuthorByConsole();

            int publishYear = Program.GetIntInputByConsole("publish year");

            _ = new Book(bookName, bookAuthor, publishYear);

            Console.WriteLine("-------------------------------------------\n" +
                              "-------- Book created successfully! -------\n" +
                              "-------------------------------------------");
        }

        public static Book GetBook(int id)
        {
            return _ = Array.Find(_allBooks, n => n.BookId == id);
        }

        public static bool CheckId(int id)
        {
            return Array.Exists(_allBooks, n => n.BookId == id);
        }
    }
}
