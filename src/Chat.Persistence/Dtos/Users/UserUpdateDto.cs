using Microsoft.AspNetCore.Http;

namespace Chat.Persistence.Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public IFormFile? Avatar { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
}
