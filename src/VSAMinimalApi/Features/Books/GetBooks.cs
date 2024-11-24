
namespace VSAMinimalApi.Features.Books;

using VSAMinimalApi.Database;
using VSAMinimalApi.Database.Models;
public static class GetBooks
{
    public static IResult Handler(MyContext context, int pageNumber = 1, int pageSize = 10)
    {
        var books = context.Books
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize) 
            .ToList();
        return TypedResults.Ok(books);
    }
    internal static void MapGetBooks(this IEndpointRouteBuilder app) =>
        app.MapGet("/", Handler)
            .Produces<List<Book>>();
}