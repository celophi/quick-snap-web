namespace QuickSnapWeb.API.Accounts;

public sealed class Account
{
    public required string Username { get; set; }

    public required string Password { get; set; }

    public required string DeviceName { get; set; }

    public required string DeviceManufacturer { get; set; }

    public required string Token { get; set; }
}
