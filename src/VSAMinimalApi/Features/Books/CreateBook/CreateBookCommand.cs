namespace VSAMinimalApi.Features.Books.CreateBook;

/// <summary>
///     Represents a command to create a Book.
/// </summary>
/// <param name="Title">Title of the book.</param>
/// <param name="PublishedDate">The date when the book was published.</param>
/// <param name="AuthorName">The name of the book's author.</param>


public record CreateBookCommand(string Title, DateOnly PublishedDate, string AuthorName);