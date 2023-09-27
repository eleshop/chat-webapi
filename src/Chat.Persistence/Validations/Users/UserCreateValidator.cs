using Chat.Persistence.Dtos.Users;
using FluentValidation;

namespace Chat.Persistence.Validations.Users;

public class UserCreateValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateValidator()
    {
        RuleFor(dto => dto.PhoneNumber)
            .NotNull().NotEmpty().WithMessage("User phone number is required!")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is incorrect!");
    }
}
