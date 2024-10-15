using Microsoft.Extensions.Caching.Memory;

namespace QuickSnapWeb.API.Pictures;

public sealed class PicturesService(IMemoryCache _memoryCache) : IPicturesService
{
    public async Task SubmitAsync(int accountId, byte[] data, string contentType)
    {
        var pictures = await GetAsync(accountId);
        pictures!.Add(new Picture { ContentType = contentType, Data = data });

        _memoryCache.Set(GetCacheKey(accountId), pictures);
    }

    public async Task<List<Picture>> GetAsync(int accountId)
    {
        if (!_memoryCache.TryGetValue(GetCacheKey(accountId), out List<Picture> pictures))
        {
            pictures = [];
        }

        return pictures;
    }

    private string GetCacheKey(int accountId) => $"pictures-{accountId}";
}
