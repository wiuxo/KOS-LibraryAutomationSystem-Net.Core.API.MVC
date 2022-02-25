using FluentValidation;
using KOS.Business.Auth.Handlers.Commands;
using KOS.Business.Auth.Handlers.Queries;
using KOS.Core;
using KOS.Core.Constants;

namespace KOS.Business.Auth;

public class RegisterValidator : CustomValidator<RegisterUser>
{
    public RegisterValidator()
    {
        RuleFor(x => x.UserName).MaximumLength(16).WithMessage("Username must be 16 or less characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.Password).Must(RegularEx.IsSafePassw).WithMessage(ValidatorMessage.IsSafePassw);
        RuleFor(x => x.FirstName).MaximumLength(16).WithMessage("Firstname must be 16 or less characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.LastName).MaximumLength(16).WithMessage("Lastname must be 16 or less characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
    }
}

public class LoginValidator : CustomValidator<LoginUser>
{
    public LoginValidator()
    {
        RuleFor(x => x.UserName).MaximumLength(16).WithMessage("Username must be less than 16 characters").NotEmpty()
            .WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.Password).Must(RegularEx.IsSafePassw).WithMessage(ValidatorMessage.IsSafePassw);
    }
}

public class AddUserRoleValidator : CustomValidator<AddUserRole>
{
    public AddUserRoleValidator()
    {
        RuleFor(x => x.userID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.roleID).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class RemoveUserValidator : CustomValidator<RemoveUser>
{
    public RemoveUserValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class RemoveUserRoleValidator : CustomValidator<RemoveUserRole>
{
    public RemoveUserRoleValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class GetRolesByUserIdValidator : CustomValidator<GetRolesByUserId>
{
    public GetRolesByUserIdValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}