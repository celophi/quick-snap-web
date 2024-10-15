using System.ComponentModel.DataAnnotations;

namespace QuickSnapWeb.API.Accounts;

public sealed record AccountRegisterApiRequestModel
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string DeviceName { get; init; }

    [Required]
    public required string DeviceManufacturer { get; init; }
}
