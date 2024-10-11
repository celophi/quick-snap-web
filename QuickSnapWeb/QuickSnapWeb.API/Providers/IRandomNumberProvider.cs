namespace QuickSnapWeb.API.Providers;

public interface IRandomNumberProvider
{
    /// <summary>
    /// Returns a new random number.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    int Get(int min, int max);
}
