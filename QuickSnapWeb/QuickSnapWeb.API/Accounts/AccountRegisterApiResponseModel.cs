namespace QuickSnapWeb.API.Accounts;

public sealed record AccountRegisterApiResponseModel
{
    public string? Token { get; init; }
}
