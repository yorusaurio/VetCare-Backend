using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Services.Communication;

namespace VetCare.API.Appointment.Domain.Services;

public interface IPetService
{
    Task<IEnumerable<Pet>> ListAsync();
    Task<PetResponse> SaveAsync(Pet pet);
    Task<PetResponse> UpdateAsync(int id, Pet pet);
    Task<PetResponse> DeleteAsync(int id);
}