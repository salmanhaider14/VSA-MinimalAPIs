using System.ComponentModel.DataAnnotations;

namespace VSAMinimalApi.Database.Models;

public class Book
{
    public int Id { get; set; }
    [MaxLength(250)] 
    public required string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    [MaxLength(250)] 
    public required string AuthorName { get; set; }
    
}