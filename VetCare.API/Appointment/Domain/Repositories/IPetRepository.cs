using VetCare.API.Appointment.Domain.Models;

namespace VetCare.API.Appointment.Domain.Repositories;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> ListAsync();
    Task AddAsync(Pet pet);
    Task<Pet> FindByIdAsync(int id);
    void Update(Pet pet);
    void Remove(Pet pet);    

}