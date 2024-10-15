namespace QuickSnapWeb.API.Pictures;

public class PictureResponse
{
    public required byte[] Data { get; init; }
    public required string ContentType { get; init; }
}
