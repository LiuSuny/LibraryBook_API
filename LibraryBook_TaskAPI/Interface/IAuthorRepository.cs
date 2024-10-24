using LibraryBook_TaskAPI.Models;

namespace LibraryBook_TaskAPI.Interface
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author?> GetByIdAsync(Guid id);
        Task<Author> CreateAsync(Author author);
        Task<Author?> UpdateAsync(Guid id, Author author);
        Task<Author?> DeleteAsync(Guid id);
    }
}
