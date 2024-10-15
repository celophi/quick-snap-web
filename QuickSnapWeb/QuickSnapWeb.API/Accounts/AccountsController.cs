using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuickSnapWeb.API.Accounts;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class AccountsController(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
{
    [HttpPost]
    [AllowAnonymous]
    public ActionResult<AccountRegisterApiResponseModel> Register(AccountRegisterApiRequestModel request)
    {
        var account = accountService.Create(request.Username, request.Password, request.DeviceManufacturer, request.DeviceName);

        return new AccountRegisterApiResponseModel
        {
            Token = account.Token,
        };
    }

    [HttpGet]
    public ActionResult Test()
    {

        var claims = httpContextAccessor.HttpContext.User.Claims;

        return new OkResult();
    }
}
