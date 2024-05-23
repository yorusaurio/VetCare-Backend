namespace VetCare.API.Center.Domain.Models;

public class Veterinary
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Ranking { get; set; }
    public string Description { get; set; }
    
    public string Address { get; set; }
    
    public string phoneNumber { get; set; }
    
    public string imageUrl { get; set; }
    
    
    // Relationships
    public int VetId { get; set; }
    public Vet Vet { get; set; }
}