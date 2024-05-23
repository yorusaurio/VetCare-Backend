using System.ComponentModel.DataAnnotations;

namespace VetCare.API.Center.Resources;

public class SaveVeterinaryResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    public int PetId { get; set; }
    
    [Required]
    public string Ranking { get; set; }

    [Required]
    public string Address { get; set; }
    
    [Required]
    public string phoneNumber { get; set; }
    
    [Required]
    public string imageUrl { get; set; }

    
    
}