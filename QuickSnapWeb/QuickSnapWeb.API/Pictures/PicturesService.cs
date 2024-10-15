using Microsoft.Extensions.Caching.Memory;
using QuickSnapWeb.API.Providers;

namespace QuickSnapWeb.API.Pictures;

public sealed class PicturesService(IMemoryCache _memoryCache, IDateTimeProvider _dateTimeProvider) : IPicturesService
{
    public async Task SubmitAsync(string accountId, byte[] data, string contentType)
    {
        var pictures = await GetAsync(accountId);
        pictures!.Add(new Picture { ContentType = contentType, Data = data, Date = _dateTimeProvider.UtcNow() });

        _memoryCache.Set(GetCacheKey(accountId), pictures);
    }

    public async Task<List<Picture>> GetAsync(string accountId)
    {
        if (!_memoryCache.TryGetValue(GetCacheKey(accountId), out List<Picture> pictures))
        {
            pictures = [];
        }

        return pictures;
    }

    private string GetCacheKey(string accountId) => $"pictures-{accountId}";
}
