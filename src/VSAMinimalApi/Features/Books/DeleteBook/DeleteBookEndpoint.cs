namespace VSAMinimalApi.Features.Books.DeleteBook;

public static class DeleteBookEndpoint{
    internal static void MapDeleteBook(this IEndpointRouteBuilder app) =>
        app.MapDelete("/{bookId}", DeleteBookHandler.Handler)
            .Produces(statusCode:204);
}