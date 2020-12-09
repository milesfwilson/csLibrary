using System;
using CodeLibrary.Services;
using CodeLibrary.Models;
using System.Collections.Generic;

namespace CodeLibrary.Controllers
{

  class LibraryController
  {
    private bool _running { get; set; }
    public LibraryService _service { get; set; } = new LibraryService();
    public void Run()
    {
      _running = true;

      while (_running)
      {
        GetUserInput();
      }
    }

    public LibraryController()
    {
      Run();
    }
    public string GetBooks(bool available)
    {
      List<Book> Books = _service.books;
      string list = "";
      for (int i = 0; i < Books.Count; i++)
      {
        var book = Books[i];
        if (book.IsAvailable == available)
        {
          list += $@"
          {i + 1}. {book.Title} by {book.Author}";
        }
      }

      return list;
    }
    private void GetUserInput()
    {

      Console.WriteLine("Options:\nAdd, Info, Checkout, Return, Delete, Quit \nWhat would you like to do?");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "add":
          Add();
          break;
        case "info":
          Read();
          break;
        case "checkout":
          Checkout();
          break;
        case "return":
          Return();
          break;
        case "delete":
          Delete();
          break;
        case "quit":
          _running = false;
          break;
        default:
          Console.WriteLine("Invalid Command");
          break;
      }
    }
    private void Add()
    {
      Console.Clear();
      System.Console.WriteLine("Enter a Title");
      string bookTitle = Console.ReadLine();
      System.Console.WriteLine("Enter an Author");
      string bookAuthor = Console.ReadLine();
      System.Console.WriteLine("Enter a description");
      string bookDescription = Console.ReadLine();
      Book newBook = new Book(bookTitle, bookAuthor, bookDescription);
      _service.Add(newBook);
      System.Console.WriteLine($"Added {bookTitle} to the library!");
    }
    private void Read()
    {
      Console.Clear();
      System.Console.WriteLine("Enter the title of the book would you like to read?");
      List<Book> Books = _service.books;
      string list = "";
      for (int i = 0; i < Books.Count; i++)
      {
        var book = Books[i];
        {
          list += $@"
          {book.Title} by {book.Author}";
        }
      }

      System.Console.WriteLine(list);
      string title = Console.ReadLine();
      _service.Read(title);
    }
    private void Checkout()
    {
      Console.Clear();
      System.Console.WriteLine(GetBooks(true));
      System.Console.WriteLine("Which book would you like to checkout?");
      string userInput = Console.ReadLine();
      if (int.TryParse(userInput, out int selection) && selection > 0)
      {
        Console.Clear();
        System.Console.WriteLine("Success!");
        _service.Checkout(selection - 1);
      }
      else
      {
        System.Console.WriteLine("Invalid");
      }
    }
    private void Return()
    {
      Console.Clear();
      System.Console.WriteLine(GetBooks(false));
      System.Console.WriteLine("Which book would you like to return?");
      string userInput = Console.ReadLine();
      if (int.TryParse(userInput, out int selection) && selection > 0)
      {
        Console.Clear();
        System.Console.WriteLine("Success!");
        _service.Return(selection - 1);
      }
      else
      {
        System.Console.WriteLine("Invalid");
      }
    }
    private void Delete()
    {
      Console.Clear();
      System.Console.WriteLine("Enter the title of the book would you like to delete?");
      List<Book> Books = _service.books;
      string list = "";
      for (int i = 0; i < Books.Count; i++)
      {
        var book = Books[i];
        {
          list += $@"
          {book.Title} by {book.Author}";
        }
      }

      System.Console.WriteLine(list);
      string title = Console.ReadLine();
      _service.Delete(title);
    }
  }
}