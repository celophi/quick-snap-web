namespace QuickSnapWeb.API.Pictures;

public interface IPicturesService
{
    Task SubmitAsync(int accountId, byte[] data, string contentType);
    Task<List<Picture>> GetAsync(int accountId);
}
