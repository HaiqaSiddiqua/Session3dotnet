using Session1LinqApp.DTOs;
using Session1LinqApp.Models;

namespace Session1LinqApp.Mappers
{
    public static class BookMapper
    {
        // 1. Translates an incoming Create DTO into a raw database Entity
        public static Book ToEntity(this BookCreateDTO dto)
        {
            return new Book
            {
                // Id will be assigned automatically by your service layer later
                Title = dto.Title,
                Year = dto.Year,
                PageCount = dto.PageCount,
                AuthorId = dto.AuthorId
            };
        }

        // 2. Translates a raw database Entity into a clean, read-only Response DTO
        public static BookResponseDTO ToResponse(this Book book)
        {
            return new BookResponseDTO
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                PageCount = book.PageCount,
                AuthorId = book.AuthorId
            };
        }

        // 3. Takes an incoming Update DTO and copies its values directly onto an existing database Entity
        public static void ApplyUpdate(this BookUpdateDTO dto, Book existingBook)
        {
            existingBook.Title = dto.Title;
            existingBook.Year = dto.Year;
            existingBook.PageCount = dto.PageCount;
            existingBook.AuthorId = dto.AuthorId;
        }
    }
}
