namespace VetCare.API.Appointment.Resources;

public class PetResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public float Weight { get; set; }
    public string Type { get; set; }
    public string photoUrl { get; set; }
    public string Color { get; set; }
    public DateTime date { get; set; }
}