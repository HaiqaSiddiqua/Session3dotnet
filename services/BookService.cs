using Session1LinqApp.Data;
using Session1LinqApp.Models;
using Session1LinqApp.Exceptions; 
using Session1LinqApp.DTOs;    
using Session1LinqApp.Mappers;  

namespace Session1LinqApp.Services;

public class BookService : IBookService
{
    // 1. GET ALL with Filter and Pagination
    public Task<List<BookResponseDTO>> GetAllAsync(string? author, int page, int pageSize)
    {
        // Start with the raw collection query
        IEnumerable<Book> query = InMemoryStore.Books;
        var authorsList = InMemoryStore.Authors;

        // Apply Author Filtering if a search string is provided
        if (!string.IsNullOrWhiteSpace(author))
        {
            // Find authors whose names contain the search string
            var targetAuthorIds = authorsList
                .Where(a => a.Name.Contains(author, StringComparison.OrdinalIgnoreCase))
                .Select(a => a.Id);

            query = query.Where(b => targetAuthorIds.Contains(b.AuthorId));
        }

        // Step B: Apply Pagination Math (Skip and Take)
        var paginatedResults = query
            .Skip((page - 1) * pageSize) // Jumps over records from previous pages
            .Take(pageSize)             // Restricts output to the page limit size
            .Select(b => b.ToResponse()) // Maps each matching Book Entity to a BookResponseDTO
            .ToList();

        return Task.FromResult(paginatedResults);
    }

    // 2. GET BY ID (Returns Response DTO)
    public Task<BookResponseDTO> GetByIdAsync(int id)
    {
        var book = InMemoryStore.Books.FirstOrDefault(b => b.Id == id);
        
        if (book == null)
        {
            throw new BookNotFoundException(id);
        }

        // Translate the found Entity into a safe Response DTO before passing it up
        return Task.FromResult(book.ToResponse());
    }

    // 3. CREATE (Accepts Create DTO)
    public Task CreateAsync(BookCreateDTO dto)
    {
        // Use your mapper to build a fresh, unindexed Book Entity object
        Book entity = dto.ToEntity();

        // Calculate and apply the next available primary ID index
        entity.Id = InMemoryStore.Books.Any() ? InMemoryStore.Books.Max(b => b.Id) + 1 : 1;
        
        InMemoryStore.Books.Add(entity);
        return Task.CompletedTask;
    }

    // 4. UPDATE (Accepts Update DTO)
    public async Task UpdateAsync(BookUpdateDTO dto)
    {
        // First, check if the record exists using our internal collection logic
        var existingBook = InMemoryStore.Books.FirstOrDefault(b => b.Id == dto.Id);
        if (existingBook == null)
        {
            throw new BookNotFoundException(dto.Id);
        }

        // Use your mapper to overwrite properties on the existing live object
        dto.ApplyUpdate(existingBook);

        await Task.CompletedTask;
    }

    // 5. DELETE
    public Task DeleteAsync(int id)
    {
        var book = InMemoryStore.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            throw new BookNotFoundException(id);
        }

        InMemoryStore.Books.Remove(book);
        return Task.CompletedTask;
    }
}
