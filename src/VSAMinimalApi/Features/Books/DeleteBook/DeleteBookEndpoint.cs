namespace VSAMinimalApi.Features.Books.DeleteBook;

/// <summary>
///     Contains the endpoint configuration for deleting a book.
/// </summary>
public static class DeleteBookEndpoint{
    /// <summary>
    ///     Maps the endpoint for deleting a book to the application's endpoint route builder.
    ///     This method sets up a DELETE endpoint at ("/books/{bookId}") to handle book deletion requests.
    ///     It uses the <see cref="DeleteBookHandler.Handler"/> to process the request and produces a response
    ///     of 204 (No Content) status code upon success.
    /// </summary>
    internal static void MapDeleteBook(this IEndpointRouteBuilder app) =>
        app.MapDelete("/{bookId}", DeleteBookHandler.Handler)
            .Produces(statusCode:204);
}