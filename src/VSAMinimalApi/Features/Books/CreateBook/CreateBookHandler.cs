using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VSAMinimalApi.Database;
using VSAMinimalApi.Database.Models;

namespace VSAMinimalApi.Features.Books.CreateBook;

/// <summary>
///     Handles requests for creating a new book.
/// </summary>
public static class CreateBookHandler
{
    /// <summary>
    ///     Validates the input, creates a new book, and saves it to the database.
    /// </summary>
    /// <param name="validator">The validator for <see cref="CreateBookCommand"/>.</param>
    /// <param name="command">The details of the book to create.</param>
    /// <param name="context">The database context.</param>
    /// <returns>
    ///     A validation error if the input is invalid, or a 201 response with the created book.
    /// </returns>
    public static Results<ValidationProblem,Created<Book>> Handler([FromServices] IValidator<CreateBookCommand> validator,CreateBookCommand command,MyContext context)
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