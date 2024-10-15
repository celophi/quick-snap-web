namespace QuickSnapWeb.API.Pictures;

public sealed record PictureSubmitApiRequestModel
{
    public required byte[] Data { get; init; }
    public required string ContentType { get; init; }
}
