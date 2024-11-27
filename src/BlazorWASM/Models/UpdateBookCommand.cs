using System.ComponentModel.DataAnnotations;

namespace BlazorWASM.Models;

/// <summary>
/// Represents a command to update an existing book.
/// </summary>
public class UpdateBookCommand
{
    [Required] public  string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    [Required] public  string AuthorName { get; set; }
}