namespace QuickSnapWeb.Accounts;

public interface IAccountsProvider
{
    Task<AccountsLoginResponseViewModel> LoginAsync(AccountsLoginRequestViewModel request);
}
