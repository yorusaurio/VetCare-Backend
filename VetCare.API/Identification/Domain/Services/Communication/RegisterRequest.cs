using System.ComponentModel.DataAnnotations;

namespace VetCare.API.Identification.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required] 
    public string Password { get; set; }
}