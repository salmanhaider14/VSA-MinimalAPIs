namespace VSAMinimalApi.Features.Books.UpdateBook;

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VSAMinimalApi.Database;
public static class UpdateBookHandler
{
    public static IResult Handler(int bookId, [FromServices]IValidator<UpdateBookCommand> validator, UpdateBookCommand command,MyContext context,[FromServices] IMemoryCache cache)
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