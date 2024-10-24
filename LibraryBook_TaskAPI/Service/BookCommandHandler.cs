using LibraryBook_TaskAPI.Data;
using LibraryBook_TaskAPI.Interface;
using LibraryBook_TaskAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryBook_TaskAPI.MediatorHandlerService
{
    public class BookCommandHandler : IBookRepository
    {
        private readonly LibraryBookContext _context;
        public BookCommandHandler(LibraryBookContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> DeleteAsync(Guid id)
        {
            var existingbook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (existingbook == null)
            {
                return null;
            }
            _context.Books.Remove(existingbook);
            await _context.SaveChangesAsync();
            return existingbook;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> UpdateAsync(Guid id, Book book)
        {
            var existingbook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingbook == null)
            {
                return null;
            }
            existingbook.Title = book.Title;
            existingbook.AuthorId = book.AuthorId;
            existingbook.PublishedYear = book.PublishedYear;
            existingbook.Genre = book.Genre;
            await _context.SaveChangesAsync();
            return existingbook;
        }
    }
}
