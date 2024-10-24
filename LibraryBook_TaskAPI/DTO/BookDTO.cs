using LibraryBook_TaskAPI.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LibraryBook_TaskAPI.DTO
{
    public class BookDTO 
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string AuthorId { get; set; }
        [Required]
        public int PublishedYear { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
