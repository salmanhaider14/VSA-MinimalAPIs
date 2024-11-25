using Microsoft.AspNetCore.Http.HttpResults;
using VSAMinimalApi.Database.Models;

namespace VSAMinimalApi.Features.Books.UpdateBook;

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VSAMinimalApi.Database;
public static class UpdateBookHandler
{
    /// <summary>
    ///     Handles updating an existing book in the database.
    /// </summary>
    /// <param name="bookId">The ID of the book to update.</param>
    /// <param name="validator">The validator for validating the update command.</param>
    /// <param name="command">The update command containing the new book details.</param>
    /// <param name="context">The database context for accessing books.</param>
    /// <param name="cache">The memory cache for clearing the cache entry of the updated book.</param>
    /// <returns>The updated book or an appropriate error response.</returns>

    public static Results<NotFound,ValidationProblem,Ok<Book>> Handler(int bookId, [FromServices]IValidator<UpdateBookCommand> validator, UpdateBookCommand command,MyContext context,[FromServices] IMemoryCache cache)
    {
        var bookToUpdate = context.Books.FirstOrDefault(b => b.Id == bookId);
        if (bookToUpdate is null) return TypedResults.NotFound();
        
        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
            return TypedResults.ValidationProblem(validationResult.ToDictionary());

        bookToUpdate.Title = command.Title;
        bookToUpdate.PublishedDate = command.PublishedDate;
        bookToUpdate.AuthorName = command.AuthorName;
        
        context.SaveChanges();
        cache.Remove($"Book_{bookId}");
        return TypedResults.Ok(bookToUpdate);

    }
}