using FluentValidation;

namespace VSAMinimalApi.Features.Books.CreateBook;

/// <summary>
///     Validates the input for creating a book.
/// </summary>
public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        /// <summary>
        ///     Defines validation rules for the <see cref="CreateBookCommand"/>.
        /// </summary>
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
