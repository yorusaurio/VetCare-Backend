using VetCare.API.Shared.Domain.Services.Communication;
using VetCare.API.Appointment.Domain.Models;

namespace VetCare.API.Appointment.Domain.Services.Communication;

public class PetResponse : BaseResponse<Pet>
{
    public PetResponse(string message) : base(message)
    {
    }

    public PetResponse(Pet resource) : base(resource)
    {
    }
}