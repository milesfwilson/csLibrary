using System;
using System.Collections.Generic;
using CodeLibrary.Models;
using CodeLibrary.Controllers;

namespace CodeLibrary.Services
{

  class LibraryService
  {
    public List<Book> books { get; set; } = new List<Book>();
    Book dune = new Book("Dune", "Frank Herbert", "Science Fiction");
    Book steveJobs = new Book("Steve Jobs", "Walter Isaacson", "Biography");
    Book lotr = new Book("Lord of the Rings", "JRR Tolkien", "Fantasy");
    Book hp = new Book("Harry Potter and the Sorcerors Stone", "JK Rowling", "Fantasy");
    public LibraryService()
    {
      books.Add(dune);
      books.Add(steveJobs);
      books.Add(lotr);
      books.Add(hp);

      // books.ForEach(book =>
      // {
      //   System.Console.WriteLine($@"
      //   {book.Title}
      //   {book.Author}
      //   {book.Description}");
      // });
    }

    internal string Add(Book newBook)
    {
      books.Add(newBook);
      return " ";
    }

    internal string Read(string title)
    {

      var index = books.FindIndex(book => book.Title == title);
      if (index != -1)
      {
        System.Console.WriteLine($"{books[index].Description}");
      }
      else
      {
        System.Console.WriteLine("Please enter the title correctly");
      }
      return "";
    }

    internal string Delete(string title)
    {
      var index = books.FindIndex(book => book.Title == title);
      if (index != -1)
      {
        System.Console.WriteLine("Are you sure? Enter Y/N");
        string userInput = Console.ReadLine();
        if (userInput == "Y" || userInput == "y")
        {

          books.RemoveAt(index);
          System.Console.WriteLine($"{title} is deleted!");
        }
      }
      else
      {
        System.Console.WriteLine("Please enter the title correctly");
      }
      return "";
    }
    internal string Checkout(int selection)
    {
      var Books = books.FindAll(book => book.IsAvailable == true);
      if (selection <= Books.Count)
      {
        books[selection].IsAvailable = false;
        System.Console.WriteLine($"Enjoy reading {books[selection].Title}");
        return " ";
      }
      else
      {
        return "Invalid input";
      }

    }

    internal string Return(int selection)
    {
      var Books = books.FindAll(book => book.IsAvailable == false);
      if (selection <= Books.Count)
      {
        books[selection].IsAvailable = true;
        System.Console.WriteLine($"Thank you for returning {books[selection].Title}");
        return " ";
      }
      else
      {
        return "Invalid input";
      }

    }

  }
}