using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VSAMinimalApi.Database;
using VSAMinimalApi.Database.Models;

namespace VSAMinimalApi.Features.Books.CreateBook;
public static class CreateBookHandler
{
    public static IResult Handler([FromServices] IValidator<CreateBookCommand> validator,CreateBookCommand command,MyContext context)
    {
        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
            return TypedResults.ValidationProblem(validationResult.ToDictionary());
        
        var newBook = new Book
        {
            Title = command.Title,
            PublishedDate = command.PublishedDate,
            AuthorName = command.AuthorName
        };
        context.Books.Add(newBook);
        context.SaveChanges();
        return TypedResults.Created($"/books/{newBook.Id}", newBook);
        
    }
}