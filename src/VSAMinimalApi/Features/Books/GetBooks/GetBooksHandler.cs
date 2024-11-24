namespace VSAMinimalApi.Features.Books.GetBooks;
using VSAMinimalApi.Database;

public static class GetBooksHandler
{
    public static IResult Handler(MyContext context, int pageNumber = 1, int pageSize = 10)
    {
        var books = context.Books
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize) 
            .ToList();
        return TypedResults.Ok(books);
    }
}