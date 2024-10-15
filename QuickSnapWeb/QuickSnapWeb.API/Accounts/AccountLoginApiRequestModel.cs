using System.ComponentModel.DataAnnotations;

namespace QuickSnapWeb.API.Accounts;

public class AccountLoginApiRequestModel
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}
