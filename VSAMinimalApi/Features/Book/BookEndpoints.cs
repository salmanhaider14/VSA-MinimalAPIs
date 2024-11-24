namespace VSAMinimalApi.Features.Book;

using VSAMinimalApi.Database.Models;

public static class BookEndpoints
{ 
    public static void MapBookEndpoints(this WebApplication app)
    {
        var productGroup = app.MapGroup("/books");
        
        productGroup.MapGet("/", GetBooks.Handler).Produces<List<Database.Models.Book>>();
        productGroup.MapGet("/{bookId}",GetBook.Handler).Produces<GetBook.GetBookResponse>();
        productGroup.MapPost("/", CreateBook.Handler).Produces<Database.Models.Book>(statusCode:201);
        productGroup.MapPut("/{bookId}", UpdateBook.Handler).Produces(statusCode:204);
        productGroup.MapDelete("/{bookId}", DeleteBook.Handler).Produces(statusCode:204);

    }
}
