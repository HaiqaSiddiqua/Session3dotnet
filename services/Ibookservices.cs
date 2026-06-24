using Session1LinqApp.DTOs;

namespace Session1LinqApp.Services;

public interface IBookService
{
    Task<List<BookResponseDTO>> GetAllAsync(string? author, int page, int pageSize);
    
    Task<BookResponseDTO> GetByIdAsync(int id); 
    Task CreateAsync(BookCreateDTO dto);
    Task UpdateAsync(BookUpdateDTO dto);
    Task DeleteAsync(int id);
}
