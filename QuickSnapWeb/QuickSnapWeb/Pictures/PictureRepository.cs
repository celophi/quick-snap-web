using Microsoft.Extensions.Caching.Memory;

namespace QuickSnapWeb.Pictures;

public class PictureRepository(IPictureProvider _pictureProvider, IMemoryCache _memoryCache) : IPictureRepository
{
    public async Task<List<Picture>> GetAsync()
    {
        var token = _memoryCache.Get("authToken") as string;
        var pictureResponse = await _pictureProvider.GetAsync(token!);

        return pictureResponse.Pictures.Select(p => new Picture
        {
            ContentType = p.ContentType,
            Data = p.Data,
            Date = p.Date
        }).ToList();
    }
}
