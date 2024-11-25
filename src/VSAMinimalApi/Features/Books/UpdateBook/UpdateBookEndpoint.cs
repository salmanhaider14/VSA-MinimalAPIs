namespace VSAMinimalApi.Features.Books.UpdateBook;

public static  class UpdateBookEndpoint
{
    /// <summary>
    ///     Maps the endpoint for updating a book to the application's endpoint route builder.
    ///     This method sets up a PUT endpoint at ("/books/{bookId}") to handle book update requests.
    ///     It uses the <see cref="UpdateBookHandler.Handler"/> to process the request and produces a response
    ///     of 204 (No Content) status code upon success.
    /// </summary>
    internal static void MapUpdateBook(this IEndpointRouteBuilder app) =>
        app.MapPut("/{bookId}", UpdateBookHandler.Handler)
            .Produces(statusCode:204);
}