namespace QuickSnapWeb.API.Accounts;

public interface IAccountService
{
    /// <summary>
    /// Creates a new account and stores it in cache.
    /// Note that this doesn't handle number conflicts. It will just overwrite the entry.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="deviceManufacturer"></param>
    /// <param name="deviceName"></param>
    /// <returns></returns>
    Account Create(string username, string password, string deviceManufacturer, string deviceName);
}
