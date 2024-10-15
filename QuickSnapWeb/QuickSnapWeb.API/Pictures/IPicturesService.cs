namespace QuickSnapWeb.API.Pictures;

public interface IPicturesService
{
    Task SubmitAsync(string accountId, byte[] data, string contentType);
    Task<List<Picture>> GetAsync(string accountId);
}
