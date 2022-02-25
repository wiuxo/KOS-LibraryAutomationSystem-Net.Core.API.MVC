using FluentValidation;
using KOS.Business.Handlers.Queries;
using KOS.Core;
using KOS.Core.Constants;

namespace KOS.Business.ValidationRules;

public class GetBookByIdValidator : CustomValidator<GetBookByIdQuery>
{
    public GetBookByIdValidator()
    {
        RuleFor(x => x.BookID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class GetBookByTitleValidator : CustomValidator<GetBookByTitleQuery>
{
    public GetBookByTitleValidator()
    {
        RuleFor(x => x.Title).MaximumLength(64).WithMessage("Must be maximum of 64 characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
    }
}

public class GetBooksByAuthorValidator : CustomValidator<GetBooksByAuthorQuery>
{
    public GetBooksByAuthorValidator()
    {
        RuleFor(x => x.Author).MaximumLength(64).WithMessage("Must be maximum of 64 characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
    }
}

public class GetBooksByGenreValidator : CustomValidator<GetBooksByGenreQuery>
{
    public GetBooksByGenreValidator()
    {
        RuleFor(x => x.Genre).MaximumLength(64).WithMessage("Must be maximum of 64 characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
    }
}