using System.ComponentModel.DataAnnotations;

namespace BlazorWASM.Models;

/// <summary>
/// Represents a command to create a new book.
/// </summary>
public class CreateBookCommand
{
    [Required] public  string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    [Required] public  string AuthorName { get; set; }
}