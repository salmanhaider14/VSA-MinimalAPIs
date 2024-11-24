namespace VSAMinimalApi.Features.Book;
using VSAMinimalApi.Database;
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
}