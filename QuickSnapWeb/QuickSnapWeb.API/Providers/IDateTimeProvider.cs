namespace QuickSnapWeb.API.Providers;

public interface IDateTimeProvider
{
    /// <summary>
    /// Returns the current date time in UTC format.
    /// </summary>
    /// <returns></returns>
    DateTime UtcNow();
}
