namespace VSAMinimalApi.Features.Books.UpdateBook;

public record UpdateBookCommand(string Title, DateOnly PublishedDate, string AuthorName);