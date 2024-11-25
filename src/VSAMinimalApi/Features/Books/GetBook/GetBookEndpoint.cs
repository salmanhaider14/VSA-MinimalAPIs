
namespace VSAMinimalApi.Features.Books.GetBook;

public static class GetBookEndpoint
{
    /// <summary>
    ///     Maps the endpoint for getting a book to the application's endpoint route builder.
    ///     This method sets up a GET endpoint at ("/books/{bookId}") to handle book get requests.
    ///     It uses the <see cref="GetBookHandler.Handler"/> to process the request and produces a response
    ///     of <see cref="GetBookResponse"/> with 200 status code upon success.
    /// </summary>
    internal static void MapGetBook(this IEndpointRouteBuilder app) =>
        app.MapGet("/{bookId}", GetBookHandler.Handler);
}