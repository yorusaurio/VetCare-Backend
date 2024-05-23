namespace VetCare.API.Center.Resources;

public class VeterinaryResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Ranking { get; set; }
    public string Description { get; set; }
    
    public string Address { get; set; }
    
    public string phoneNumber { get; set; }
    
    public string imageUrl { get; set; }

    
    
    
    public VetResource Vet { get; set; }
}