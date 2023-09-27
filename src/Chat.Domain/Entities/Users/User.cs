namespace Chat.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string Avatar { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;
}
