using Microsoft.AspNetCore.Components;
using QuickSnapWeb.Accounts;
using System.ComponentModel.DataAnnotations;

namespace QuickSnapWeb.Pages;

public partial class Home
{
    [Inject]
    private IAccountsRepository _accountsRepository { get; init; } = default!;

    [Inject]
    private NavigationManager _navigationManager { get; init; } = default!;

    private LoginModel loginModel = new();

    private async Task OnLogin()
    {
        var isLoggedIn = await _accountsRepository.LoginAsync(loginModel.Username, loginModel.Password);

        if (isLoggedIn)
        {
            _navigationManager.NavigateTo("/pictures");
        }
    }

    private class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
