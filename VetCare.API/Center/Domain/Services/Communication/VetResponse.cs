using VetCare.API.Center.Domain.Models;
using VetCare.API.Shared.Domain.Services.Communication;

namespace VetCare.API.Center.Domain.Services.Communication;

public class VetResponse : BaseResponse<Vet>
{
    public VetResponse(string message) : base(message)
    {
    }

    public VetResponse(Vet resource) : base(resource)
    {
    }
}