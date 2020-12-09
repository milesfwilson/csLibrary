using System;
using CodeLibrary.Models;
using CodeLibrary.Services;
using CodeLibrary.Controllers;

namespace CodeLibrary
{
  class Program
  {
    public LibraryController _controller { get; set; } = new LibraryController();
    static void Main(string[] args)
    {
      new LibraryController();

    }
  }
}
