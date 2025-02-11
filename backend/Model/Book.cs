namespace Backend.Model;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Represents a book in the database.
/// </summary>
[Table("books")]
public class Book
{
    /// <summary>
    /// Gets the unique database identifier of the book.
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets the title of the book. 
    /// </summary>
    [Column("title")]
    public string Title { get; set; }
}