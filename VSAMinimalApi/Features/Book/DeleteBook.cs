using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VSAMinimalApi.Database;

namespace VSAMinimalApi.Features.Book;

using VSAMinimalApi.Database;

public static class DeleteBook{
    
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