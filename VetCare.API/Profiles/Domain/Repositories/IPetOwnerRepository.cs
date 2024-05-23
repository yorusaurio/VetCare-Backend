using VetCare.API.Profiles.Domain.Models;

namespace VetCare.API.Profiles.Domain.Repositories;

public interface IPetOwnerRepository
{
    Task<IEnumerable<PetOwner>> ListAsync();
    Task AddAsync(PetOwner petOwner);
    Task<PetOwner> FindByIdAsync(int id);
    void Update(PetOwner petOwner);
    void Remove(PetOwner petOwner);

}