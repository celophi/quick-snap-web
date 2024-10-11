namespace QuickSnapWeb.API.Providers;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc/>
    public DateTime UtcNow() => DateTime.UtcNow;
}
