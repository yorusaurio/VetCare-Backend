using VetCare.API.Center.Domain.Models;

namespace VetCare.API.Center.Domain.Repositories;

public interface IVeterinaryRepository
{
    Task<IEnumerable<Veterinary>> ListAsync();
    Task AddAsync(Veterinary veterinary);
    Task<Veterinary> FindByIdAsync(int veterinaryId);
    Task<Veterinary> FindByTitleAsync(string title);
    Task<IEnumerable<Veterinary>> FindByVetIdAsync(int vetId);
    void Update(Veterinary veterinary);
    void Remove(Veterinary veterinary);
}