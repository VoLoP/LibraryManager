using System;
﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class LibraryManager
    {
        private List<Book> books = new List<Book>();
        private int nextId = 1;
        private const string FilePath = "books.json";

        public LibraryManager()
        {
            LoadBooks();
        }

        public void AddBook(string title, string author)
        {
            var book = new Book
            {
                Id = nextId++,
                Title = title,
                Author = author
            };
            books.Add(book);
            SaveBooks();
            Console.WriteLine($"Book '{title}' by {author} added with ID {book.Id}.");
        }

        public void RemoveBook(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                SaveBooks();
                Console.WriteLine($"Book with ID {id} removed.");
            }
            else
            {
                Console.WriteLine($"Book with ID {id} not found.");
            }
        }

        public void EditBook(int id, string newTitle, string newAuthor)
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                SaveBooks();
                Console.WriteLine($"Book with ID {id} updated to '{newTitle}' by {newAuthor}.");
            }
            else
            {
                Console.WriteLine($"Book with ID {id} not found.");
            }
        }

        public void ListBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
            }
        }

        private void SaveBooks()
        {
            var json = JsonConvert.SerializeObject(books);
            File.WriteAllText(FilePath, json);
        }

        private void LoadBooks()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                books = JsonConvert.DeserializeObject<List<Book>>(json);
                if (books.Count > 0)
                {
                    nextId = books.Max(b => b.Id) + 1;
                }
            }
        }
    }
}
