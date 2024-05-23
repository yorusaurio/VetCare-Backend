using System.ComponentModel.DataAnnotations;

namespace VetCare.API.Appointment.Resources;

public class SavePrescriptionResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    public int PetId { get; set; }
    
    [Required]
    public bool Published { get; set; }
}