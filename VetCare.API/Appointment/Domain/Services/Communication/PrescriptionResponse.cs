using VetCare.API.Shared.Domain.Services.Communication;
using VetCare.API.Appointment.Domain.Models;

namespace VetCare.API.Appointment.Domain.Services.Communication;

public class PrescriptionResponse : BaseResponse<Prescription>
{
    public PrescriptionResponse(string message) : base(message)
    {
    }

    public PrescriptionResponse(Prescription resource) : base(resource)
    {
    }
}