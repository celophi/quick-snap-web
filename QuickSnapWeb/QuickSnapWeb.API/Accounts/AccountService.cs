﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using QuickSnapWeb.API.Providers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickSnapWeb.API.Accounts;

internal sealed class AccountService(
    IRandomNumberProvider randomNumberProvider,
    IMemoryCache memoryCache,
    IDateTimeProvider dateTimeProvider) : IAccountService
{
    /// <inheritdoc/>
    public Account Create(string name)
    {
        var randomNumber = randomNumberProvider.Get(1000, 9999);

        var account = new Account
        {
            Name = name,
            Code = randomNumber,
            Token = this.CreateToken(randomNumber)
        };

        var expiration = dateTimeProvider.UtcNow().AddYears(1);
        memoryCache.Set(randomNumber, account, expiration);

        return account;
    }

    private string CreateToken(int accountId)
    {
        var secret = "SuperDuperSecretKeyThatIsSoLongYouWillNeverGuessItBwahaha64Characters!";
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha512);
        var expiration = dateTimeProvider.UtcNow().AddYears(1);

        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, accountId.ToString()),
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
