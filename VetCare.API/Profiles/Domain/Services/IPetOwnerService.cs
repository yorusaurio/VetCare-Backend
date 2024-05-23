using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Profiles.Domain.Services.Communication;

namespace VetCare.API.Profiles.Domain.Services;

public interface IPetOwnerService
{
    Task<IEnumerable<PetOwner>> ListAsync();
    Task<PetOwnerResponse> SaveAsync(PetOwner petOwner);
    Task<PetOwnerResponse> UpdateAsync(int id, PetOwner petOwner);
    Task<PetOwnerResponse> DeleteAsync(int id);
}