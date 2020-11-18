﻿using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Data.Repositories
{
    public class BooksStateRepository : IBooksStateRepository
    {
        private readonly DataContext _dataContext;

        public BooksStateRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public List<Book> GetAllAvailableBooks()
        {
            return _dataContext.BookState.AllBooks.Books;
        }

        public int GetAmountOfAvailableBooksById(int id)
        {
            var book = _dataContext.BookState.AllBooks.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (book != null && _dataContext.BookState.AvailableBooksAmount.ContainsKey(book))
            {
                var amount = _dataContext.BookState.AvailableBooksAmount[book];

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            var updatedBook = _dataContext.BookState.AllBooks.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (updatedBook != null && _dataContext.BookState.AvailableBooksAmount.ContainsKey(updatedBook))
            {
                _dataContext.BookState.AvailableBooksAmount[updatedBook] = actualBooksAmount;
            }

            return actualBooksAmount;
        }
    }
}