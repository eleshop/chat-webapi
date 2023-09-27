using Microsoft.AspNetCore.Http;

namespace Chat.Persistence.Dtos.Users;

public class UserCreateDto
{
    public IFormFile Avatar { get; set; } = default!;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;
}
