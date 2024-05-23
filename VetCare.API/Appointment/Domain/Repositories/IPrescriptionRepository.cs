using VetCare.API.Appointment.Domain.Models;

namespace VetCare.API.Appointment.Domain.Repositories;

public interface IPrescriptionRepository
{
    Task<IEnumerable<Prescription>> ListAsync();
    Task AddAsync(Prescription prescription);
    Task<Prescription> FindByIdAsync(int prescriptionId);
    Task<Prescription> FindByTitleAsync(string title);
    Task<IEnumerable<Prescription>> FindByPetIdAsync(int petId);
    void Update(Prescription prescription);
    void Remove(Prescription prescription);
}