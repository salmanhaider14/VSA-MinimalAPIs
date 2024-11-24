using FluentValidation;

namespace VSAMinimalApi.Features.Books.UpdateBook;

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