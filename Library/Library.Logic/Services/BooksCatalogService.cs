﻿using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class BooksCatalogService : IBookCatalogService
    {
        private readonly IBooksCatalogRepository booksCatalogRepository;

        public BooksCatalogService(IBooksCatalogRepository booksCatalogRepository)
        {
            this.booksCatalogRepository = booksCatalogRepository;
        }

        public void AddBook(Book book)
        {
            booksCatalogRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            booksCatalogRepository.DeleteBook(id);
        }

        public void EditBook(Book book)
        {
            booksCatalogRepository.EditBook(book);
        }

        public List<Book> GetAllBooks()
        {
            var books = booksCatalogRepository.GetAllBooks().ToList();

            return books.Count == 0 ? null : books;
        }

        public Book GetBook(int id)
        {
            var bookById = booksCatalogRepository.GetBookById(id);

            if (bookById.Equals(null)) return null;

            return bookById;
        }

        public Book GetBook(BookEnum bookType)
        {
            var bookByType = booksCatalogRepository.GetBookByType(bookType);

            if (bookByType.Equals(null)) return null;

            return bookByType;
        }
    }
}