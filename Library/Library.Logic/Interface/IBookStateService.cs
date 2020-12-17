using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;

namespace Library.Logic
{
    public interface IBookStateService
    {
        List<Book> GetAllAvailableBooks();
        int GetAmountOfAvailableBooks(int dictionaryId);
        void UpdateBooksAmount(int dictionaryId, int actualBooksAmount);
    }
}
