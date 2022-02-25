using FluentValidation;
using KOS.Business.Handlers.Commands;
using KOS.Core;
using KOS.Core.Constants;

namespace KOS.Business.ValidationRules;

public class AddBookValidator : CustomValidator<AddBookCommand>
{
    public AddBookValidator()
    {
        RuleFor(x => x.Title).MaximumLength(64).WithMessage("Must be maximum of 64 characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.Author).MaximumLength(64).NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.Genre).MaximumLength(64).WithMessage("Must be maximum of 64 characters");
        RuleFor(x => x.Subject).MaximumLength(64).WithMessage("Must be maximum of 64 characters");
    }
}

public class BorrowBookValidator : CustomValidator<BorrowBookCommand>
{
    public BorrowBookValidator()
    {
        RuleFor(x => x.UserID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.BookID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class HoldBookValidator : CustomValidator<HoldBookCommand>
{
    public HoldBookValidator()
    {
        RuleFor(x => x.UserID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.BookID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class RemoveBookValidator : CustomValidator<RemoveBookCommand>
{
    public RemoveBookValidator()
    {
        RuleFor(x => x.BookID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class ReturnBookValidator : CustomValidator<ReturnBookCommand>
{
    public ReturnBookValidator()
    {
        RuleFor(x => x.BookID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class BringBackRemovedBookValidator : CustomValidator<BringBackRemovedBookCommand>
{
    public BringBackRemovedBookValidator()
    {
        RuleFor(x => x.BookID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}