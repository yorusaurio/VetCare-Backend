using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Shared.Domain.Services.Communication;

namespace VetCare.API.Profiles.Domain.Services.Communication;

public class PetOwnerResponse : BaseResponse<PetOwner>
{
    public PetOwnerResponse(string message) : base(message)
    {
    }

    public PetOwnerResponse(PetOwner resource) : base(resource)
    {
    }
}