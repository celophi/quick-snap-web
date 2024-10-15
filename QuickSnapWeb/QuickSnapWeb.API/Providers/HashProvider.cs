

using System.Security.Cryptography;
using System.Text;

namespace QuickSnapWeb.API.Providers;

public class HashProvider : IHashProvider
{
    public string Hash(string input)
    {
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

        var builder = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            builder.Append(hash[i].ToString("x2"));
        }

        return builder.ToString();
    }
}
