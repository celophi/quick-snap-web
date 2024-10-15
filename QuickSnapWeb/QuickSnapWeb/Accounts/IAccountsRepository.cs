namespace QuickSnapWeb.Accounts;

public interface IAccountsRepository
{
    Task<bool> LoginAsync(string username, string password);
}
