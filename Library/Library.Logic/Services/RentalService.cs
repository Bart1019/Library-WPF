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
        private OurLibrary availableLibraryBooks = new OurLibrary();

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
                OnUserRent(rentalUser);

                OnBookRent(book, false);

                rentalRepository.AddRental(rental);

                return rental;
            }

            return null;
        }


        public void GiveBookBack(int rentalId, int bookId, int userId, DateTime rentalEnd)
        {
            throw new NotImplementedException();
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

        private void OnBookRent(Book book, bool rentalState)
        {
            book.IsAvailable = rentalState;
            libraryRepository.AddBookWithChangedState(book, rentalState);
        }

        private void OnUserRent(User rentalUser)
        {
            rentalUser.AmountOfBooksRented++;
            rentalRepository.AddUserToRentalHistory(rentalUser);
        }
    }
}
