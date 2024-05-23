namespace VetCare.API.Appointment.Domain.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Breed { get; set; }
    public float Weight { get; set; }
    public string photoUrl { get; set; }
    public string Color { get; set; }
    
    public DateTime Date { get; set; }
    
    
    // Relationships
    
    public IList<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    
}
