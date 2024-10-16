﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using QuickSnapWeb.API.Providers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickSnapWeb.API.Accounts;

internal sealed class AccountService(
    IHashProvider _hashProvider,
    IMemoryCache _memoryCache,
    IDateTimeProvider dateTimeProvider) : IAccountService
{
    public async Task<Account?> LoginAsync(string username, string password)
    {
        var accountId = _hashProvider.Hash($"{username}:{password}");
        _memoryCache.TryGetValue(accountId, out Account account);

        return account;
    }

    /// <inheritdoc/>
    public Account Create(string username, string password, string deviceManufacturer, string deviceName)
    {
        var accountId = _hashProvider.Hash($"{username}:{password}");
        var account = new Account
        {
            Username = username,
            Password = password,
            DeviceManufacturer = deviceManufacturer,
            DeviceName = deviceName,
            Token = this.CreateToken(accountId)
        };

        var expiration = dateTimeProvider.UtcNow().AddYears(1);
        _memoryCache.Set(accountId, account, expiration);

        return account;
    }

    private string CreateToken(string accountId)
    {
        var secret = "SuperDuperSecretKeyThatIsSoLongYouWillNeverGuessItBwahaha64Characters!";
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha512);
        var expiration = dateTimeProvider.UtcNow().AddYears(1);

        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, accountId),
            new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(dateTimeProvider.UtcNow()).ToUnixTimeSeconds().ToString()),
            new(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expiration).ToUnixTimeSeconds().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "localhost",
            audience: "QuickSnap",
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
