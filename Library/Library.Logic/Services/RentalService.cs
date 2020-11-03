using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class RentalService
    {
        private readonly IRentalRepository rentalRepository;
        private readonly ILibraryRepository libraryRepository;
        private readonly IUserRepository userRepository;
        private readonly OurLibrary availableLibraryBooks = new OurLibrary();

        public RentalService(IRentalRepository rentalRepository, ILibraryRepository libraryRepository, IUserRepository userRepository)
        {
            this.rentalRepository = rentalRepository;
            this.libraryRepository = libraryRepository;
            this.userRepository = userRepository;
        }

        public List<Rental> GetAllRentals()
        {
            List<Rental> rentals =  rentalRepository.GetAllRentals();

            return rentals.Count == 0 ? null : rentals;
        }

        public Rental GetRental(int id)
        {
            Rental rental = rentalRepository.GetRentalById(id);

            if (rental.Equals(null))
            {
                return null;
            }

            return rental;
        }

        public void DeleteRental(int id)
        {
            rentalRepository.DeleteRental(id);
        }

        public void EditExistingRental(Rental existingRental)
        {
            rentalRepository.EditRental(existingRental);
        }

        public Rental CreateNewRental(int rentalId, int userId, int bookId, DateTime rentalDate)
        {
            User rentalUser = userRepository.GetUserById(userId);
            availableLibraryBooks.Books = libraryRepository.GetAllAvailableBooks().ToList();
            Rental rental = InitializeRental(rentalId, rentalDate, rentalUser, availableLibraryBooks, bookId, out Book book);

            if (ValidateData(rentalUser, book, rentalDate))
            {
                OnUserRent(rentalUser, true);

                OnBookRent(book, false);

                rentalRepository.AddRental(rental);

                return rental;
            }

            return null;
        }


        public void GiveBookBack(Rental rental, int bookId, DateTime rentalEnd)
        {
            Rental endedRental = rentalRepository.GetRentalById(rental.Id);
            User rentalUser = endedRental.RentalUser;
            Book giveBackBook = endedRental.LibraryBooks.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (!endedRental.Equals(null))
            {
                OnUserRent(rentalUser, false);

                OnBookRent(giveBackBook, true);

                endedRental.GiveBackDate = rentalEnd;
                endedRental.LibraryBooks = rental.LibraryBooks;
                endedRental.RentalUser = default;
                endedRental.RentalDate = default;
            }

            rentalRepository.EditRental(endedRental);
        }

        private Rental InitializeRental(int id, DateTime rentalDate, User rentalUser, OurLibrary library, int bookId, out Book book)
        {
            book = library.Books.FirstOrDefault(i => i.Id.Equals(bookId) && i.IsAvailable.Equals(true));

            return new Rental
            {
                Id = id,
                RentalDate = rentalDate,
                GiveBackDate = default,
                RentalUser = rentalUser,
                LibraryBooks = library
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

        private void OnBookRent(Book book, bool isAvailable)
        {
            book.IsAvailable = isAvailable;
            libraryRepository.UpdateBookState(book, isAvailable);
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
