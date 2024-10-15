namespace QuickSnapWeb.Pictures;

public interface IPictureRepository
{
    Task<List<Picture>> GetAsync();
}
