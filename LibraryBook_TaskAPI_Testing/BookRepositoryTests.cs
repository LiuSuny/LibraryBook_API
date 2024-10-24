using LibraryBook_TaskAPI.Data;
using LibraryBook_TaskAPI.MediatorHandlerService;
using LibraryBook_TaskAPI.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryBook_TaskAPI_Testing
{
    public class BookRepositoryTests
    {
        private readonly BookCommandHandler _repository;
        private readonly LibraryBookContext  _context;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<LibraryBookContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new LibraryBookContext(options);
            _repository = new BookCommandHandler(_context);
        }

        [Fact]
        public async Task AddBook_ShouldAddBook()
        {
            var book = new Book { Title = "Test Book", AuthorId = new Guid("F7248FC3-2585-4EFB-8D1D-1C555F4087F6"), PublishedYear = 2020, Genre = "Action" };
            await _repository.CreateAsync(book);

            var result = await _repository.GetAllBooksAsync();
            Assert.Single(result);
        }
    }
}