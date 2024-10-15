namespace QuickSnapWeb.API.Accounts;

public sealed record AccountRegisterApiResponseModel
{
    public required string Token { get; init; }
}
