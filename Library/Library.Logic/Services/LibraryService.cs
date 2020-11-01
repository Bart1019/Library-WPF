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
            return libraryRepository.GetAllAvailableBooks().ToList();
        }

        public List<Book> GetAllUnavailableBooks()
        {
            return libraryRepository.GetAllUnavailableBooks().ToList();
        }
    }
}
