using LibraryBook_TaskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBook_TaskAPI.Data
{
    //connect to db class
    public class LibraryBookContext  : DbContext
    {
        public LibraryBookContext(DbContextOptions<LibraryBookContext> options) : base(options)
        {
                
        }
        //db tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        //seed some data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Todo: Seed data here
            var book = new List<Book>()
             {
                new Book
               {
                 Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                 Title = "Fortune of Time",
                 AuthorId =  Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                 PublishedYear = 2022-09-10,
                 Genre = "Thriller"

               },
                 new Book
                 {
                     Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                     Title = "Dark Skies",
                     AuthorId = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                     PublishedYear = 1999-09-10,
                     Genre = "Action"
                 },
                 new Book
                 {
                     Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                     Title = "Vanish in the Sunset",
                     AuthorId = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                     PublishedYear = 2010-07-10,
                     Genre = "Drama"
                 }

             };
            
            modelBuilder.Entity<Book>().HasData(book);

            var author = new List<Author>()
            {
            new Author
            {
                Id =  Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                FullName = "Billy Spark",
                Birthday = new DateTime(1993-09-20)
            },
                new Author
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                   FullName = "Dark Skies",
                   Birthday = new DateTime(1985-09-20)

                },
                new Author
                {
                    Id =  Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    FullName = "Vanish in the Sunset",
                    Birthday = new DateTime(2003-10-20)

                }
            };
            modelBuilder.Entity<Author>().HasData(author);
        }
    
    }
}
