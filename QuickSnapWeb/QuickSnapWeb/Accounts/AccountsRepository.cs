using Microsoft.Extensions.Caching.Memory;

namespace QuickSnapWeb.Accounts;

public class AccountsRepository(IAccountsProvider _accountsProvider, IMemoryCache _memoryCache) : IAccountsRepository
{
    public async Task<bool> LoginAsync(string username, string password)
    {
        var response = await _accountsProvider.LoginAsync(new AccountsLoginRequestViewModel { Username = username, Password = password });

        if (response.Token is not null)
        {
            _memoryCache.Set("authToken", response.Token);
            return true;
        }

        return false;
    }
}
