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

        return $"{books[index].Description}";

      }
      else
      {

        return "Please enter the title correctly";
      }
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
          return $"{title} is deleted!";

        }
      }
      else
      {
        return "Please enter the title correctly";

      }
      return "";
    }
    internal string Checkout(int selection)
    {
      var Books = books.FindAll(book => book.IsAvailable == true);
      if (selection <= books.Count)
      {
        books[selection].IsAvailable = false;

        return $"Enjoy reading {books[selection].Title}";
      }
      else
      {
        return "Invalid input";
      }

    }

    internal string Return(int selection)
    {
      var Books = books.FindAll(book => book.IsAvailable == false);
      if (selection <= books.Count)
      {
        books[selection].IsAvailable = true;

        return $"Thank you for returning {books[selection].Title}";
      }
      else
      {
        return "Invalid input";
      }

    }

  }
}