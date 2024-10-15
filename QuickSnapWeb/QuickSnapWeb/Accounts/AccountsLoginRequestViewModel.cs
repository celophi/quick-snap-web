namespace QuickSnapWeb.Accounts;

public sealed record AccountsLoginRequestViewModel
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
