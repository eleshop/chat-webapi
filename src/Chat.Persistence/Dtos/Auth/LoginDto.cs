﻿namespace Chat.Persistence.Dtos.Auth;

public class LoginDto
{
    public string PhoneNumber { get; set; } = String.Empty;

    public string Password { get; set; } = string.Empty;
}
