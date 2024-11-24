namespace VSAMinimalApi.Features.Book;

using VSAMinimalApi.Database;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
public static class UpdateBook
{
    public record UpdateBookCommand(string Title, DateOnly PublishedDate, string AuthorName);
    
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
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
    internal static void MapUpdateBook(this IEndpointRouteBuilder app) =>
        app.MapPut("/{bookId}", Handler)
            .Produces(statusCode:204);
}