
namespace VSAMinimalApi.Features.Book;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VSAMinimalApi.Database;
public static class GetBook
{
    public record GetBookResponse(int Id, string Title, DateOnly PublishedDate, string AuthorName);
    public static  IResult Handler(MyContext context,[FromServices] IMemoryCache cache, int bookId)
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