using Microsoft.AspNetCore.Http.HttpResults;

namespace VSAMinimalApi.Features.Books.GetBook;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VSAMinimalApi.Database;

public static class GetBookHandler
{
    /// <summary>
    ///     Retrieves a book by its ID from the database or cache.
    /// </summary>
    /// <param name="context">The database context for accessing books.</param>
    /// <param name="cache">The memory cache for storing book data temporarily.</param>
    /// <param name="bookId">The ID of the book to retrieve.</param>
    /// <returns>The book details if found; otherwise, a 404 response.</returns>
    public static  Results<NotFound,Ok<GetBookResponse>> Handler(MyContext context,[FromServices] IMemoryCache cache, int bookId)
    {
        var cacheKey = $"Book_{bookId}";
        if (!cache.TryGetValue(cacheKey, out GetBookResponse bookRes))
        {
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);
        
            if (book is null) return TypedResults.NotFound();
            bookRes = new GetBookResponse(book.Id, book.Title, book.PublishedDate, book.AuthorName);
            cache.Set(cacheKey, bookRes, TimeSpan.FromMinutes(5));
        }
        
        return TypedResults.Ok(bookRes);
    }
}