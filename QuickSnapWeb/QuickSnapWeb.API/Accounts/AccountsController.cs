using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuickSnapWeb.API.Accounts;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class AccountsController(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
{
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AccountRegisterApiResponseModel>> Login(AccountLoginApiRequestModel request)
    {
        var account = await accountService.LoginAsync(request.Username, request.Password);

        return new AccountRegisterApiResponseModel
        {
            Token = account?.Token,
        };
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public ActionResult<AccountRegisterApiResponseModel> Register(AccountRegisterApiRequestModel request)
    {
        var account = accountService.Create(request.Username, request.Password, request.DeviceManufacturer, request.DeviceName);

        return new AccountRegisterApiResponseModel
        {
            Token = account.Token,
        };
    }
}
