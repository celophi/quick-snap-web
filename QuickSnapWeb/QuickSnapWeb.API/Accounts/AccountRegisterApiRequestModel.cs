using System.ComponentModel.DataAnnotations;

namespace QuickSnapWeb.API.Accounts;

public sealed record AccountRegisterApiRequestModel
{
    [Required]
    public required string Name { get; set; }
}
