using VetCare.API.Center.Domain.Models;
using VetCare.API.Shared.Domain.Services.Communication;

namespace VetCare.API.Center.Domain.Services.Communication;

public class VeterinaryResponse : BaseResponse<Veterinary>
{
    public VeterinaryResponse(string message) : base(message)
    {
    }

    public VeterinaryResponse(Veterinary resource) : base(resource)
    {
    }
}