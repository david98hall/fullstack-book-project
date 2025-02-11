namespace Backend.Data;

using Microsoft.EntityFrameworkCore;
using Backend.Model;

/// <summary>
/// Bridge between the application and the database.
/// </summary>
public class BookContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BookContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    /// <summary>
    /// Gets or sets the set of <see cref="Book"/> objects.
    /// </summary>
    public DbSet<Book> Books { get; set; }
}