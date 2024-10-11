namespace QuickSnapWeb.API.Providers;

public sealed class RandomNumberProvider : IRandomNumberProvider
{
    private static readonly Random _random = new();

    /// <inheritdoc/>
    public int Get(int min, int max) =>
        _random.Next(min, max);
}
