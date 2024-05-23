namespace VetCare.API.Appointment.Domain.Models;

public class Prescription
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Published { get; set; }
    
    
    // Relationships
    public int PetId { get; set; }
    public Pet Pet { get; set; }
}