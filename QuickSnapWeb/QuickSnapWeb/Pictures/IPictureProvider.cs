namespace QuickSnapWeb.Pictures;

public interface IPictureProvider
{
    Task<PicturesResponseViewModel> GetAsync(string token);
}
