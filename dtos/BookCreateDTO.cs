using System.ComponentModel.DataAnnotations;

namespace Session1LinqApp.DTOs
{
    public class BookCreateDTO
    {
        [Required(ErrorMessage = "Title is mandatory.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1400, 2026, ErrorMessage = "Year must be between 1400 and the current year.")]
        public int Year { get; set; }

        [Range(1, 5000, ErrorMessage = "Page count must be between 1 and 5,000.")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Author ID must be linked to this book.")]
        public int AuthorId { get; set; }
    }
}
