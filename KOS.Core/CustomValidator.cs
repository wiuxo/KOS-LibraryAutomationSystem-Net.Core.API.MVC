using FluentValidation;
using FluentValidation.Results;

namespace KOS.Core;

public class CustomValidator<TEntity> : AbstractValidator<TEntity>
{
    public override ValidationResult Validate(ValidationContext<TEntity> context)
    {
        var validationResult = base.Validate(context);
        if (!validationResult.IsValid) validationResult.Errors.ToList();

        return validationResult;
    }
}