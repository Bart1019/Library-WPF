using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;
using Book = Library.Data.Models.BooksCatalog.Book;

namespace Library.Logic.Services
{
    public class BookEventService
    {
        private readonly IBookEventRepository bookEventRepository;
        private readonly IBooksStateRepository booksStateRepository;
        private readonly IUserRepository userRepository;
        private readonly BooksState availableLibraryBooks = new BooksState();

        public BookEventService(IBookEventRepository bookEventRepository, IBooksStateRepository booksStateRepository, IUserRepository userRepository)
        {
            this.bookEventRepository = bookEventRepository;
            this.booksStateRepository = booksStateRepository;
            this.userRepository = userRepository;
        }

        public List<BookEvent> GetAllBookEvents()
        {
            List<BookEvent> rentals =  bookEventRepository.GetAllBookEvents();

            return rentals.Count == 0 ? null : rentals;
        }

        public RentalEvent RentBook(int userId, int bookId, DateTime rentalDate)
        {
            int availableAmountOfParticularBook = booksStateRepository.GetAmountOfAvailableBooksById(bookId);
            User rentalUser = userRepository.GetUserById(userId);
            availableLibraryBooks.BooksCatalog = new BooksCatalog
            {
                Books = booksStateRepository.GetAllAvailableBooks()
            };

            RentalEvent rental = InitializeEvent(rentalDate, rentalUser, availableLibraryBooks, bookId, out Book book);

            if (ValidateData(rentalUser, book, rentalDate))
            {
                OnUserRent(rentalUser, true);

                OnBookRent(book.Id, --availableAmountOfParticularBook);

                bookEventRepository.AddRentalEvent(rental);

                return rental;
            }

            return null;
        }

        public void ReturnBook(int userId, int bookId, DateTime returnDate)
        {
            int availableAmountOfParticularBook = booksStateRepository.GetAmountOfAvailableBooksById(bookId);
            User rentalUser = userRepository.GetUserById(userId);
            Book returnedBook = availableLibraryBooks.BooksCatalog.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (ValidateData(rentalUser, returnedBook, returnDate))
            {
                OnUserRent(rentalUser, false);

                OnBookRent(returnedBook.Id, ++availableAmountOfParticularBook);

                ReturnEvent returnEvent = new ReturnEvent
                {
                    RentalUser = rentalUser,
                    ReturnDate = returnDate
                };

                bookEventRepository.AddReturnEvent(returnEvent);
            }
        }

        private RentalEvent InitializeEvent(DateTime rentalDate, User rentalUser, BooksState booksState, int bookId, out Book book)
        {
            book = booksState.BooksCatalog.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            return new RentalEvent
            {
                RentalDate = rentalDate,
                RentalUser = rentalUser,
                BooksInLibrary = booksState
            };
        }

        private bool ValidateData(User user, Book book, DateTime date)
        {
            if (user.Equals(null) || book.Equals(null) || date.Equals(null))
            {
                return false;
            }

            return true;
        }

        private void OnBookRent(int bookId, int amountOfBooks)
        {
            booksStateRepository.UpdateBooksAmount(bookId, amountOfBooks);
        }

        private void OnUserRent(User rentalUser, bool isRenting)
        {
            if (isRenting)
            {
                rentalUser.AmountOfBooksRented++;
            }
            else
            {
                rentalUser.AmountOfBooksRented--;
            }
        }
    }
}
