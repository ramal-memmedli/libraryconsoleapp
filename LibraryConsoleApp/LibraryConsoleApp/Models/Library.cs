using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Models
{
    public class Library
    {
        private static int _idCounter;
        private static Library[] _libraries;

        private static Book[] _books;

        public static int Length { get; private set; }
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string LocatedCity { get; set; }

        public static Library[] Libraries { get { return _libraries; } }

        private Book this[int index]
        {
            get { return _books[index]; }
            set { _books[index] = value; }
        }

        static Library()
        {
            _idCounter = 0;
            _libraries = new Library[0];
            _books = new Book[0];
        }

        private Library()
        {
            LibraryId = ++_idCounter;
            Array.Resize(ref _libraries, _libraries.Length + 1);
            _libraries[^1] = this;
        }

        public Library(string name, string locatedCity) : this()
        {
            Name = name;
            LocatedCity = locatedCity;
        }

        public static void AddBook(Book book)
        {
            if (_books.Contains(book))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"----- Selected book already in library ----\n" +
                                  "-------------------------------------------");
            }
            else
            {
                Array.Resize(ref _books, _books.Length + 1);
                _books[^1] = book;
                Length++;

                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                             $"--------- Book added successfully ---------\n" +
                              "-------------------------------------------");
            }
        }

        public static void RemoveBook(Book book)
        {
            if (_books.Contains(book))
            {
                book = _books[^1];
                Array.Resize(ref _books, _books.Length - 1);
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                             $"-------- Book removed successfully --------\n" +
                              "-------------------------------------------");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"----- Selected book is not in library -----\n" +
                                  "-------------------------------------------");
            }
        }

        private static void PrintBooks(Library library)
        {
            for (int i = 0; i < _books.Length; i++)
            {
                Console.WriteLine($"Id : {_books[i].BookId} {_books[i].Name} Book author : {_books[i].Author.Name} {_books[i].Author.Surname} Publish year : {_books[i].PublishYear}");
            }
        }

        public static void CreateLibraryByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                              "------------ Create new library -----------\n" +
                              "-------------------------------------------");
            string name = Program.GetStringInputByConsole("library name");

            string locatedCity = Program.GetStringInputByConsole("city which library is located");

            Library library = new Library(name, locatedCity);

            Console.Clear();
            Console.WriteLine("-------------------------------------------\n" +
                              "------- Library created successfully! -----\n" +
                              "-------------------------------------------");
        }

        public static void PrintLibraries()
        {
            if(_libraries.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                              "----------- there are no library ----------\n" +
                              "-------------------------------------------");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                              "--------------- All libraries -------------\n" +
                              "-------------------------------------------");

                foreach (Library library in _libraries)
                {
                    Console.WriteLine($"Id : {library.LibraryId} {library.Name} Located city : {library.LocatedCity}");
                }
                Console.WriteLine("-------------------------------------------\n");
            }
            
        }

        public static void SeeAllBooksInSpecificLibrary()
        {
            if (_libraries.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                              "----------- there are no library ----------\n" +
                              "-------------------------------------------");
            }
            else
            {
            TryAgain:
                Console.WriteLine("-------------------------------------------\n" +
                                  "----------- Select library by id ----------\n" +
                                  "-------------------------------------------");
                PrintLibraries();
                int id = Program.GetIntInputByConsole("id");

                if(id == 0)
                {
                    Console.Clear();
                    return;
                } 

                if (!CheckId(id))
                {
                    Console.WriteLine("-------------------------------------------\n" +
                                      "Selected library doesn't exist! Re enter id\n" +
                                      "-------------------------------------------");
                    goto TryAgain;
                }

                Console.WriteLine("-------------------------------------------\n" +
                                 $"------------ Library {id} selected -----------\n" +
                                  "-------------------------------------------");

                Console.WriteLine("-------------------------------------------\n" +
                                 $"-------- All books in this library --------\n" +
                                  "-------------------------------------------");

                PrintBooks(GetLibrary(id));
                if(!Book.CheckId(id))
                {
                    Console.WriteLine("------------- Library is empty ------------\n");
                }

                Console.WriteLine("-------------------------------------------\n");
            }
        }

        private static Library GetLibrary(int id)
        {
            return Array.Find(_libraries, n => n.LibraryId == id);
        }

        public static bool CheckId(int id)
        {
            return Array.Exists(_libraries, n => n.LibraryId == id);
        }

        public static void AddBookToLibrary()
        {
            TryAgain:
            
            SeeAllBooksInSpecificLibrary();
            
            Console.Clear();
            Console.WriteLine("-------------------------------------------\n" +
                             $"--------------- Select book ---------------\n" +
                              "------------- Press 0 for exit ------------");

            Book.PrintAllBooks();
            int id = Program.GetIntInputByConsole("id");

            if(id == 0)
            {
                Console.Clear();
                return;
            }

            if (!Book.CheckId(id))
            {
                Console.WriteLine("Selected book doesn't exist! Re enter id. (press 0 for exit)");
                goto TryAgain;
            }

            AddBook(Book.GetBook(id));

            
        }

        public static void RemoveBookFromLibrary()
        {
        TryAgain:
            Console.Clear();
            SeeAllBooksInSpecificLibrary();

            Console.WriteLine("-------------------------------------------\n" +
                             $"--------------- Select book ---------------\n" +
                              "------------- Press 0 for exit ------------");
            int id = Program.GetIntInputByConsole("id");

            if (id == 0)
            {
                return;
            }

            if (!Book.CheckId(id))
            {
                Console.WriteLine("Selected book doesn't exist! Re enter id. (press 0 for exit)");
                goto TryAgain;
            }

            RemoveBook(Book.GetBook(id));
            
        }
    }
}
