namespace VSAMinimalApi.Features.Books.GetBook;

/// <summary>
///     Represents a response to retrieve a Book.
/// </summary>
/// <param name="Id">Id of the book.</param>
/// <param name="Title">Title of the book.</param>
/// <param name="PublishedDate">The date when the book was published.</param>
/// <param name="AuthorName">The name of the book's author.</param>
public record GetBookResponse(int Id, string Title, DateOnly PublishedDate, string AuthorName);