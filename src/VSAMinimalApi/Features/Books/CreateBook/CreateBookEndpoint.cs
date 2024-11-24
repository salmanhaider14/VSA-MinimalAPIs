
namespace VSAMinimalApi.Features.Books.CreateBook;

using VSAMinimalApi.Database.Models;
public static  class CreateBookEndpoint
{
    internal static void MapCreateBook(this IEndpointRouteBuilder app) =>
        app.MapPost("/", CreateBookHandler.Handler)
            .Produces<Book>(statusCode:201);
}