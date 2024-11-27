namespace VSAMinimalApi.Features.Books.UpdateBook;

/// <summary>
///  Represents a command to update a SingleBook.
/// </summary>
/// <param name="Title">Title of the book.</param>
/// <param name="PublishedDate">The date when the book was published.</param>
/// <param name="AuthorName">The name of the book's author.</param>
public record UpdateBookCommand(string Title, DateOnly PublishedDate, string AuthorName);