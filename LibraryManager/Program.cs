using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var libraryManager = new LibraryManager();
            string command;

            do
            {
                DisplayMenu();
                command = Console.ReadLine();

                try
                {
                    ProcessCommand(command, libraryManager);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
            } while (command != "5");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Library Manager");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Edit Book");
            Console.WriteLine("4. List Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        private static void ProcessCommand(string command, LibraryManager libraryManager)
        {
            switch (command)
            {
                case "1":
                    AddBook(libraryManager);
                    break;

                case "2":
                    RemoveBook(libraryManager);
                    break;

                case "3":
                    EditBook(libraryManager);
                    break;

                case "4":
                    libraryManager.ListBooks();
                    break;

                case "5":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private static void AddBook(LibraryManager libraryManager)
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be empty.");
            }

            libraryManager.AddBook(title, author);
        }

        private static void RemoveBook(LibraryManager libraryManager)
        {
            Console.Write("Enter book ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int removeId))
            {
                libraryManager.RemoveBook(removeId);
            }
            else
            {
                throw new ArgumentException("Invalid ID format.");
            }
        }

        private static void EditBook(LibraryManager libraryManager)
        {
            Console.Write("Enter book ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int editId))
            {
                Console.Write("Enter new book title: ");
                string newTitle = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newTitle))
                {
                    throw new ArgumentException("New title cannot be empty.");
                }

                Console.Write("Enter new book author: ");
                string newAuthor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newAuthor))
                {
                    throw new ArgumentException("New author cannot be empty.");
                }

                libraryManager.EditBook(editId, newTitle, newAuthor);
            }
            else
            {
                throw new ArgumentException("Invalid ID format.");
            }
        }
    }
}
