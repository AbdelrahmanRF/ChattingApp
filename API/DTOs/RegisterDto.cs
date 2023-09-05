
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required] [StringLength(24, MinimumLength = 3)]
    public string Username { get; set;}
    [Required] [MinLength(8)]
    public string Password { get; set;}
}
