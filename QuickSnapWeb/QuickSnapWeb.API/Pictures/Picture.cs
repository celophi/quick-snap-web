namespace QuickSnapWeb.API.Pictures;

public sealed record Picture
{
    public DateTime Date { get; init; }
    public required byte[] Data { get; init; }
    public required string ContentType { get; init; }
}
