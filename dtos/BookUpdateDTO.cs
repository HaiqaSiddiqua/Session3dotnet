using System.ComponentModel.DataAnnotations;

namespace Session1LinqApp.DTOs
{
    public class BookUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required for updates.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1400, 2026)]
        public int Year { get; set; }

        [Range(1, 5000)]
        public int PageCount { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
