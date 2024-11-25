using Microsoft.AspNetCore.Http.HttpResults;
using VSAMinimalApi.Database.Models;
using VSAMinimalApi.Database;

namespace VSAMinimalApi.Features.Books.GetBooks;

public static class GetBooksHandler
{
    /// <summary>
    ///     Handles retrieving a paginated list of books from the database.
    /// </summary>
    /// <param name="context">The database context for accessing books.</param>
    /// <param name="pageNumber">The current page number (default is 1).</param>
    /// <param name="pageSize">The number of books per page (default is 10).</param>
    /// <returns>A paginated list of books.</returns>
    public static Ok<List<Book>> Handler(MyContext context, int pageNumber = 1, int pageSize = 10)
    {
        var books = context.Books
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize) 
            .ToList();
        return TypedResults.Ok(books);
    }
}