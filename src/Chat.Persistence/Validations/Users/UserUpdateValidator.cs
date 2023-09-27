using Chat.Persistence.Dtos.Users;
using Chat.Persistence.Helpers;
using FluentValidation;

namespace Chat.Persistence.Validations.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName)
            .Length(3, 20).WithMessage("FirstName must be between 3 and 50 characters.")
            .Matches("^[A-Za-z]+$").WithMessage("FirstName can only contain letters");

        RuleFor(dto => dto.LastName)
            .Length(3, 20).WithMessage("LastName must be between 3 and 50 characters.")
            .Matches("^[A-Za-z]+$").WithMessage("LastName can only contain letters");

 
        When(dto => dto.Avatar is not null, () =>
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.Avatar!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Avatar!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
