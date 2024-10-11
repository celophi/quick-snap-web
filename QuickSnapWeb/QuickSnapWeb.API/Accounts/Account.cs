namespace QuickSnapWeb.API.Accounts;

public sealed class Account
{
    /// <summary>
    /// User name of the account.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Temporary code for signing up.
    /// </summary>
    public int? Code { get; set; }

    public string Token { get; set; }
}
