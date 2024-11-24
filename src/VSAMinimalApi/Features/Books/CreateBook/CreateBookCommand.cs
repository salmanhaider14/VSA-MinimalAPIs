namespace VSAMinimalApi.Features.Books.CreateBook;
public record CreateBookCommand(string Title, DateOnly PublishedDate, string AuthorName);