namespace QuickSnapWeb.API.Accounts;

public sealed record AccountRegisterApiResponseModel
{
    public required string Name { get; init; }
    public required string Code { get; init; }
    public required string Token { get; init; }
}
