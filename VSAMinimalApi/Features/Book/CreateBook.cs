
namespace VSAMinimalApi.Features.Book;

using VSAMinimalApi.Database;
using VSAMinimalApi.Database.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

public static class CreateBook
{
    public record CreateBookCommand(string Title, DateOnly PublishedDate, string AuthorName);

    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.PublishedDate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("Published date cannot be in the future.");

            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(50).WithMessage("Author name cannot exceed 50 characters.");
        }
    }
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
    internal static void MapCreateBook(this IEndpointRouteBuilder app) =>
        app.MapPost("/", Handler)
            .Produces<Book>(statusCode:201);
}