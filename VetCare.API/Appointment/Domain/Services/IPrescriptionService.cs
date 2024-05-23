using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Services.Communication;

namespace VetCare.API.Appointment.Domain.Services;

public interface IPrescriptionService
{
    Task<IEnumerable<Prescription>> ListAsync();
    Task<IEnumerable<Prescription>> ListByPetIdAsync(int petId);
    Task<PrescriptionResponse> SaveAsync(Prescription prescription);
    Task<PrescriptionResponse> UpdateAsync(int prescriptionId, Prescription prescription);
    Task<PrescriptionResponse> DeleteAsync(int prescriptionId);
}