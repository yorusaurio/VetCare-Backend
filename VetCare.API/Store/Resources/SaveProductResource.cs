using System.ComponentModel.DataAnnotations;

namespace VetCare.API.Store.Resources;

public class SaveProductResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    public float Price { get; set; }
    
    [MaxLength(200)]
    public string Image { get; set; }
    
    [Required]
    public int Stock { get; set; }
}