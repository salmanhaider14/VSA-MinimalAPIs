namespace BlazorWASM.Models;

/// <summary>
/// Represents a book.
/// </summary>
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    public string AuthorName { get; set; }
}