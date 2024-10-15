using Microsoft.Extensions.Options;
using QuickSnapWeb.Configuration;
using System.Net.Http.Json;
namespace QuickSnapWeb.Accounts;

public sealed class AccountsProvider(HttpClient _httpClient, IOptions<ApiOptions> _apiOptions) : IAccountsProvider
{
    public async Task<AccountsLoginResponseViewModel> LoginAsync(AccountsLoginRequestViewModel request)
    {
        try
        {
            var url = _apiOptions.Value.ApiUrl;
            var response = await _httpClient.PostAsJsonAsync($"{_apiOptions.Value.ApiUrl}/api/accounts/login", request);
            return (await response.Content.ReadFromJsonAsync<AccountsLoginResponseViewModel>())!;
        }
        catch (Exception ex)
        {
            var a = ex;
            throw;
        }
    }
}
