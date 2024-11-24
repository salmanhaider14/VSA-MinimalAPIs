namespace VSAMinimalApi.Features.Books.GetBook;

public record GetBookResponse(int Id, string Title, DateOnly PublishedDate, string AuthorName);