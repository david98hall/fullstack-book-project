namespace Backend.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Model;
using Backend.Data;

/// <summary>
/// The MVC pattern controller. Defines a REST API with "api/books" as its endpoint base.
/// Is meant to be instantiated by ASP.NET using dependency injection.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookContext context;

    /// <summary>
    /// Initializes a new instance of <see cref="BooksController"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public BooksController(BookContext context)
    {
        this.context = context;
    }

    // GET: api/books
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await this.context.Books.ToListAsync();
        return Ok(books);
    }

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await this.context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] Book book)
    {
        this.context.Books.Add(book);
        await this.context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
    {
        var book = await this.context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        book.Title = updatedBook.Title;
        await this.context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await this.context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        this.context.Books.Remove(book);
        await this.context.SaveChangesAsync();
        return NoContent();
    }
}