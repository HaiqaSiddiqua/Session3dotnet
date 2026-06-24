using Microsoft.AspNetCore.Mvc;
using Session1LinqApp.DTOs;
using Session1LinqApp.Services;

namespace Session1LinqApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
     
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Updated GET api/books route endpoint utilizing the new filtered pagination service
        [HttpGet]
        public async Task<ActionResult<List<BookResponseDTO>>> GetBooks(
            [FromQuery] string? author, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            var books = await _bookService.GetAllAsync(author, page, pageSize);
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDTO dto)
        {
            await _bookService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetBookById), new { id = 1 }, "Book created successfully.");
        }   

        // PUT api/books
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookUpdateDTO dto)
        {
            await _bookService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
