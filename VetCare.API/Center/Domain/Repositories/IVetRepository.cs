using VetCare.API.Center.Domain.Models;

namespace VetCare.API.Center.Domain.Repositories;

public interface IVetRepository
{
    Task<IEnumerable<Vet>> ListAsync();
    Task AddAsync(Vet vet);
    Task<Vet> FindByIdAsync(int id);
    void Update(Vet vet);
    void Remove(Vet vet);    

}