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

        public RentalService(IRentalRepository rentalRepository, ILibraryRepository libraryRepository, IUserRepository userRepository)
        {
            this.rentalRepository = rentalRepository;
            this.libraryRepository = libraryRepository;
            this.userRepository = userRepository;
        }

        public List<Rental> GetAllRentals()
        {
            return rentalRepository.GetAllRentals().ToList();
        }

        public Rental GetRental(int id)
        {
            return rentalRepository.GetRentalById(id);
        }
    }
}
