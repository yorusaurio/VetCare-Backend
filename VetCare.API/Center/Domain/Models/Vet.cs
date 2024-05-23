namespace VetCare.API.Center.Domain.Models;

public class Vet
{
    public int Id { get; set; }
    
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string Birthdate { get; set; }
    public string ImageUrl { get; set; }
    
    
    
    // Relationships
    
    public IList<Veterinary> Veterinary { get; set; } = new List<Veterinary>();
    
}