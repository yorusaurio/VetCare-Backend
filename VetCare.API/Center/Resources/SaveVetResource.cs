using System.ComponentModel.DataAnnotations;

namespace VetCare.API.Center.Resources;

public class SaveVetResource
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Birthdate { get; set; }
    [Required]
    public string ImageUrl { get; set; }

}