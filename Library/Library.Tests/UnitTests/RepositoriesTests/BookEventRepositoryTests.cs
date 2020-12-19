using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Library.DataTests
{
    public class BookEventRepositoryTests
    {
        private IQueryable<RentalEvent> _rentalEvents;
        private IQueryable<ReturnEvent> _returnEvents;
        private readonly Mock<LibraryDbContext> _libraryDbContextMock;
        private readonly Mock<DbSet<RentalEvent>> _mockRentalSet;
        private readonly Mock<DbSet<ReturnEvent>> _mockReturnSet;
        private readonly BookEventRepository _bookEventRepository;

        public BookEventRepositoryTests()
        {
            _rentalEvents = new List<RentalEvent>
            {
                new RentalEvent { EventDate = default, RentalUser = default},
                new RentalEvent { EventDate = default, RentalUser = default},
                new RentalEvent { EventDate = default, RentalUser = default},
            }.AsQueryable();

            _returnEvents = new List<ReturnEvent>
            {
                new ReturnEvent { EventDate = default, RentalUser = default},
                new ReturnEvent { EventDate = default, RentalUser = default},
                new ReturnEvent { EventDate = default, RentalUser = default},
            }.AsQueryable();

            _mockRentalSet = new Mock<DbSet<RentalEvent>>();
            _mockRentalSet.As<IQueryable<RentalEvent>>().Setup(m => m.Provider).Returns(_rentalEvents.Provider);
            _mockRentalSet.As<IQueryable<RentalEvent>>().Setup(m => m.Expression).Returns(_rentalEvents.Expression);
            _mockRentalSet.As<IQueryable<RentalEvent>>().Setup(m => m.ElementType).Returns(_rentalEvents.ElementType);
            _mockRentalSet.As<IQueryable<RentalEvent>>().Setup(m => m.GetEnumerator()).Returns(_rentalEvents.GetEnumerator());

            _mockReturnSet = new Mock<DbSet<ReturnEvent>>();
            _mockReturnSet.As<IQueryable<ReturnEvent>>().Setup(m => m.Provider).Returns(_returnEvents.Provider);
            _mockReturnSet.As<IQueryable<ReturnEvent>>().Setup(m => m.Expression).Returns(_returnEvents.Expression);
            _mockReturnSet.As<IQueryable<ReturnEvent>>().Setup(m => m.ElementType).Returns(_returnEvents.ElementType);
            _mockReturnSet.As<IQueryable<ReturnEvent>>().Setup(m => m.GetEnumerator()).Returns(_returnEvents.GetEnumerator());

            _libraryDbContextMock = new Mock<LibraryDbContext>();
            _libraryDbContextMock.Setup(x => x.RentalEvents).Returns(_mockRentalSet.Object);
            _libraryDbContextMock.Setup(x => x.ReturnEvents).Returns(_mockReturnSet.Object);

            _bookEventRepository = new BookEventRepository(_libraryDbContextMock.Object);
        }

        [Fact]
        public void ShouldAddRentalEvent()
        {
            //Arrange

            //Act
            var resultedUsers = _bookEventRepository.GetAllBookRentalEvents();

            //Assert
            Assert.Equal(3, resultedUsers.Count());

        }

        [Fact]
        public void ShouldAddReturnEvent()
        {
            //Arrange

            //Act
            var resultedUsers = _bookEventRepository.GetAllBookReturnEvents();

            //Assert
            Assert.Equal(3, resultedUsers.Count());
        }

        [Fact]
        public void ShouldReturnAllRentalsEvents()
        {
            //Arrange
            var newRental = new RentalEvent {EventDate = default, RentalUser = default};

            //Act
            _bookEventRepository.AddRentalEvent(newRental);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ShouldReturnAllEReturnEvents()
        {
            //Arrange
            var newReturn = new ReturnEvent {EventDate = default, RentalUser = default};

            //Act
            _bookEventRepository.AddReturnEvent(newReturn);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}