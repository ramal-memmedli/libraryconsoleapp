using System;
using LibraryConsoleApp.Models;

namespace LibraryConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine(@" _    _      _                          
| |  | |    | |                         
| |  | | ___| | ___ ___  _ __ ___   ___ 
| |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \
\  /\  /  __/ | (_| (_) | | | | | |  __/
 \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                        
                                        ");

            Library.CreateLibraryByConsole();

            Menu:

            Console.WriteLine("1 - Create new book\n" +
                              "2 - Print all books\n" +
                              "3 - See all books in library\n" +
                              "4 - Add book to library\n" +
                              "5 - Remove book from library\n" +
                              "0 - Exit\n");

            string input = null;
            input = GetStringInputByConsole("input");

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Book.CreateBookByConsole();
                    goto Menu;
                case "2":
                    Console.Clear();
                    Book.PrintAllBooks();
                    goto Menu;
                case "3":
                    Console.Clear();
                    Library.SeeAllBooksInSpecificLibrary();
                    goto Menu;
                case "4":
                    Console.Clear();
                    Library.AddBookToLibrary();
                    goto Menu;
                case "5":
                    Console.Clear();
                    Library.RemoveBookFromLibrary();
                    goto Menu;
                case "0":
                    Console.Clear();
                        return;
                default:
                    goto Menu;

            }
        }


        public static string GetStringInputByConsole(string content)
        {
        ReEnterStringInput:
            Console.Write($"Please enter {content} : ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"--------- {content} can't be empty! --------\n" +
                                  "-------------------------------------------");
                goto ReEnterStringInput;
            }

            return input;
        }

        public static int GetIntInputByConsole(string content)
        {
            ReEnterIntInput:

            Console.Write($"Please enter {content} : ");
            string inputString = Console.ReadLine().Trim();
            int input = 0;

            try
            {
                input = Convert.ToInt32(inputString);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                  $"------- {content} must be digit! ------\n" +
                                  "-------------------------------------------");
                goto ReEnterIntInput;
            }

            return input;
        }
    }
}
