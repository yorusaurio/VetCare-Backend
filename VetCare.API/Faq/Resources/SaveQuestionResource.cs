using System.ComponentModel.DataAnnotations;

namespace VetCare.API.Faq.Resources;

public class SaveQuestionResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; }
}