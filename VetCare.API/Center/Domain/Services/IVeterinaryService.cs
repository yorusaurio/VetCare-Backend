using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Services.Communication;

namespace VetCare.API.Center.Domain.Services;

public interface IVeterinaryService
{
    Task<IEnumerable<Veterinary>> ListAsync();
    Task<IEnumerable<Veterinary>> ListByVetIdAsync(int vetId);
    Task<VeterinaryResponse> SaveAsync(Veterinary veterinary);
    Task<VeterinaryResponse> UpdateAsync(int veterinaryId, Veterinary veterinary);
    Task<VeterinaryResponse> DeleteAsync(int veterinaryId);
}