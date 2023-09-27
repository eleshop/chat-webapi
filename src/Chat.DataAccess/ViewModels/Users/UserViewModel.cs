﻿namespace Chat.DataAccess.ViewModels.Users;

public class UserViewModel
{
    public long Id { get; set; }

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string Avatar { get; set; } = String.Empty;
}
