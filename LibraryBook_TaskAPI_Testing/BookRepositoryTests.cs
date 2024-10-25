using LibraryBook_TaskAPI.Data;
using LibraryBook_TaskAPI.Interface;
using LibraryBook_TaskAPI.MediatorHandlerService;
using LibraryBook_TaskAPI.Models;
using Microsoft.EntityFrameworkCore;



namespace LibraryBook_TaskAPI_Testing
{
    public class BookRepositoryTests
    {
            
        private readonly DbContextOptions<LibraryBookContext> _context;
        public BookRepositoryTests()
        {
            _context = new DbContextOptionsBuilder<LibraryBookContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseDb")
                .Options;
        }
        private LibraryBookContext CreateDbContext() => new LibraryBookContext(_context);



        [Fact]
        public async Task GetByIdAsync_ShouldReturnBook()
        {
            //Assign(
            //db context

            var db = CreateDbContext(); //creating our db

            //act (
            // //job posting)


            var repository = new BookCommandHandler(db); //creating an instance of repository

            var books = new Book
            {
                Title = "Test Book",
                PublishedYear = 2020,
                Genre = "Fiction",
                AuthorId = new Guid("F8288FC3-2585-4EFB-8D1D-1C555F4087F7")
            };

            //execute           
            await db.Books.AddAsync(books);
            await db.SaveChangesAsync();

            var result = await repository.GetByIdAsync(books.Id);

            Assert.NotNull(result);
            Assert.Equal(2020, result.PublishedYear);
        }

       


        //Added to db InMemoryDatabase
        [Fact]
        public async Task AddBook_ShouldAddBook()
        {
            //Assign(
            //db context

            var db = CreateDbContext(); //creating our db

            //act (
            // //job posting)


            var repository = new BookCommandHandler(db);


            var book = new Book
            {
               
                Title = "Test Book",
                PublishedYear = 2020,
                Genre = "Fiction",
                AuthorId = new Guid("F8248FC3-2585-4EFB-8D1D-1C555F4087F6")
            };

            //execute
            await repository.CreateAsync(book);

            //results
            var result = db.Books.Find(book.Id);

            //assert)
            Assert.NotNull(result);

            //Assert.Equal("Tests Book", result.Title); //failed testing
            Assert.Equal("Test Book", result.Title); //passed testing

        }

        [Fact]
        public async Task UpdateBook_ShouldUpdateBook()
        {
            //Assign(
            //db context

            var db = CreateDbContext(); //creating our db

            //act (
            // //job posting)


            var repository = new BookCommandHandler(db);


            var book1 = new Book
            {

                Title = "Update Book Testing",
                PublishedYear = 2023,
                Genre = "Horror",
                AuthorId = new Guid("c309fa92-2123-47be-b397-a1c77adb502c")
            };

            //execute
            await repository.CreateAsync(book1);
            await db.SaveChangesAsync();

            //change our genre to something else
            book1.Genre = "Update Horror to K-Drama";
            await repository.UpdateAsync(book1.Id, book1);

            //results
            var result = await db.Books.FindAsync(book1.Id);

            //assert)
            Assert.NotNull(result);

            //Assert.Equal("Tests Book", result.Title); //failed testing
            Assert.Equal("Update Horror to K-Drama", result.Genre); //passed testing

        }
    }
}