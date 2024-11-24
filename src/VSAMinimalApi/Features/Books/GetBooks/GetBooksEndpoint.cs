
namespace VSAMinimalApi.Features.Books.GetBooks;

using VSAMinimalApi.Database.Models;

public static class GetBooksEndpoint
{
    internal static void MapGetBooks(this IEndpointRouteBuilder app) =>
        app.MapGet("/", GetBooksHandler.Handler)
            .Produces<List<Book>>();
}