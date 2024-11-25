
namespace VSAMinimalApi.Features.Books.CreateBook;

using VSAMinimalApi.Database.Models;

/// <summary>
///     Contains the endpoint configuration for creating a book.
/// </summary>
public static  class CreateBookEndpoint
{
    /// <summary>
    ///     Maps the endpoint for creating a book to the application's endpoint route builder.
    ///     This method sets up a POST endpoint at ("/books") to handle book creation requests.
    ///     It uses the <see cref="CreateBookHandler.Handler"/> to process the request and produces a response
    ///     of type <see cref="Book"/> with a 201 (Created) status code upon success.
    /// </summary>

    internal static void MapCreateBook(this IEndpointRouteBuilder app) =>
        app.MapPost("/", CreateBookHandler.Handler);
}