
namespace VSAMinimalApi.Features.Books.GetBooks;

using VSAMinimalApi.Database.Models;

public static class GetBooksEndpoint
{
    /// <summary>
    ///     Maps the endpoint for getting books to the application's endpoint route builder.
    ///     This method sets up a GET endpoint at ("/books") to handle book get requests.
    ///     It uses the <see cref="GetBooksHandler.Handler"/> to process the request and produces a response
    ///     of Books List with 200 status code upon success.
    /// </summary>
    internal static void MapGetBooks(this IEndpointRouteBuilder app) =>
        app.MapGet("/", GetBooksHandler.Handler)
            .Produces<List<Book>>();
}