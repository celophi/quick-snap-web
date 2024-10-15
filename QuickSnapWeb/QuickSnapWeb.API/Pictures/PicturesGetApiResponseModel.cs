namespace QuickSnapWeb.API.Pictures;

public sealed record PicturesGetApiResponseModel
{
    public List<PictureResponse> Pictures { get; set; }
}
