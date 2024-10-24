using LibraryBook_TaskAPI.Models;

namespace LibraryBook_TaskAPI.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book> CreateAsync(Book book);
        Task<Book?> UpdateAsync(Guid id, Book book);
        Task<Book?> DeleteAsync(Guid id);
    }
}
