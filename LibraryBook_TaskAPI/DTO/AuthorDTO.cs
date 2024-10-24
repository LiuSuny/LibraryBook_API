using LibraryBook_TaskAPI.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LibraryBook_TaskAPI.DTO
{
    public class AuthorDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
