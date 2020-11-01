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
        private Rental rental;
        private int initialRentalId = 0;

        public RentalService(IRentalRepository rentalRepository, ILibraryRepository libraryRepository, IUserRepository userRepository)
        {
            this.rentalRepository = rentalRepository;
            this.libraryRepository = libraryRepository;
            this.userRepository = userRepository;
        }

        public List<Rental> GetAllRentals()
        {
            List<Rental> rentals =  rentalRepository.GetAllRentals().ToList();

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

        public void CreateNewRental(int userId, int bookId, DateTime rentalDate)
        {
            User rentalUser = userRepository.GetUserById(userId);
            List<Book> availableBooks = libraryRepository.GetAllAvailableBooks().ToList();
            Book rentedBook = availableBooks.FirstOrDefault(i => i.Id.Equals(bookId));
            

            if (ValidateData(rentalUser, rentedBook, rentalDate))
            {
                initialRentalId++;

                OnUserRent(rentalUser);

                OnBookRent(rentedBook);

                rentalRepository.AddRental(rental);
            }
        }

        private bool ValidateData(User user, Book book, DateTime date)
        {
            if (user.Equals(null) || book.Equals(null) || date.Equals(null))
            {
                return false;
            }

            return true;
        }

        private void OnBookRent(Book book)
        {
            book.IsAvailable = false;
            libraryRepository.AddBookWithChangedState(book);
        }

        private void OnUserRent(User rentalUser)
        {
            rentalUser.AmountOfBooksRented++;
            rentalRepository.AddUserToRentalHistory(rentalUser);
        }
    }
}
