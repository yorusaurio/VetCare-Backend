using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Services.Communication;

namespace VetCare.API.Center.Domain.Services;

public interface IVetService
{
    Task<IEnumerable<Vet>> ListAsync();
    Task<VetResponse> SaveAsync(Vet vet);
    Task<VetResponse> UpdateAsync(int id, Vet vet);
    Task<VetResponse> DeleteAsync(int id);
}