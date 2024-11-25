using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VSAMinimalApi.Database;

namespace VSAMinimalApi.Features.Books.DeleteBook;
public static class DeleteBookHandler
{
    /// <summary>
    ///     Retrieves the book to delete, check if the book is found, and deletes it from the database.
    /// </summary>
    /// <param name="bookId">The id of the book to delete.</param>
    /// <param name="context">The database context.</param>
    /// <param name="cache">The IMemoryCache interface for caching .</param>
    /// <returns>
    ///     A Not Found error if the book isn't found, or a 204(No Content) response on success.
    /// </returns>
    public static IResult Handler(int bookId,MyContext context, [FromServices] IMemoryCache cache)
    {
        var bookToDel = context.Books.FirstOrDefault(b => b.Id == bookId);
        if (bookToDel is null) return TypedResults.NotFound();

        context.Remove(bookToDel);
        context.SaveChanges();
        
        cache.Remove($"Book_{bookId}");
        return TypedResults.NoContent();

    }
}