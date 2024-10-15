using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuickSnapWeb.API.Pictures;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class PicturesController(IHttpContextAccessor _httpContextAccessor, IPicturesService _picturesService)
{
    [HttpPost]
    public async Task<ActionResult> Submit(PictureSubmitApiRequestModel request)
    {
        var accountId = GetAccountId();
        await _picturesService.SubmitAsync(accountId, request.Data, request.ContentType);

        return new OkResult();
    }

    [HttpGet]
    public async Task<ActionResult<PicturesGetApiResponseModel>> Get()
    {
        var accountId = GetAccountId();
        var pictures = await _picturesService.GetAsync(accountId);

        return new PicturesGetApiResponseModel
        {
            Pictures = pictures.Select(Map).ToList()
        };
    }

    private PictureResponse Map(Picture picture)
    {
        return new PictureResponse { ContentType = picture.ContentType, Data = picture.Data };
    }

    private int GetAccountId()
    {
        var claim = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

        return int.Parse(claim!.Value);
    }
}