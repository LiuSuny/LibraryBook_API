using System.ComponentModel.DataAnnotations;

namespace LibraryBook_TaskAPI.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
