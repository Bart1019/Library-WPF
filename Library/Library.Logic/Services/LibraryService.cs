using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class LibraryService
    {
        private readonly ILibraryRepository libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public List<Book> GetAllAvailableBooks()
        {
            List<Book> availableBooks = libraryRepository.GetAllAvailableBooks().ToList();

            return availableBooks.Count == 0 ? null : availableBooks;
        }

        public List<Book> GetAllUnavailableBooks()
        {
            List<Book> unavailableBooks = libraryRepository.GetAllUnavailableBooks().ToList();

            return unavailableBooks.Count == 0 ? null : unavailableBooks;
        }
    }
}
