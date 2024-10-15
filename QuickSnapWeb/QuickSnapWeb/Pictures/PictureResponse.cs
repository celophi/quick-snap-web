namespace QuickSnapWeb.Pictures;

public class PictureResponse
{
    public required DateTime Date { get; init; }
    public required byte[] Data { get; init; }
    public required string ContentType { get; init; }
}
