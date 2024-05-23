namespace VetCare.API.Appointment.Resources;

public class PrescriptionResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Published { get; set; }
    public PetResource Pet { get; set; }
}