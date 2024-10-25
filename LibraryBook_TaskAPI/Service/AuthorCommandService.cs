using Azure.Core;
using LibraryBook_TaskAPI.Data;
using LibraryBook_TaskAPI.Interface;
using LibraryBook_TaskAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace LibraryBook_TaskAPI.MediatorHandlerService
{
    public class AuthorCommandService : IAuthorRepository
    {
        private readonly LibraryBookContext _context;
        public AuthorCommandService(LibraryBookContext context)
        {
            _context = context;
        }

 
        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> DeleteAsync(Guid id)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAuthor == null)
            {
                return null;
            }
            _context.Authors.Remove(existingAuthor);
            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Author?> UpdateAsync(Guid id, Author author)
        {
              var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAuthor == null)
            {
                return null;
            }
            existingAuthor.FullName = author.FullName;
            existingAuthor.Birthday = author.Birthday;
            await _context.SaveChangesAsync();
            return existingAuthor;
        }
    }
    
}
