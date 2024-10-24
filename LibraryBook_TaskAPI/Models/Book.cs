using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBook_TaskAPI.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}
