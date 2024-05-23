using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Repositories;
using VetCare.API.Appointment.Domain.Services;
using VetCare.API.Appointment.Domain.Services.Communication;

namespace VetCare.API.Appointment.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPetRepository _petRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork, IPetRepository petRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _unitOfWork = unitOfWork;
        _petRepository = petRepository;
    }

    public async Task<IEnumerable<Prescription>> ListAsync()
    {
        return await _prescriptionRepository.ListAsync();
    }

    public async Task<IEnumerable<Prescription>> ListByPetIdAsync(int petId)
    {
        return await _prescriptionRepository.FindByPetIdAsync(petId);
    }

    public async Task<PrescriptionResponse> SaveAsync(Prescription prescription)
    {
        // Validate PetId

        var existingPet = await _petRepository.FindByIdAsync(prescription.PetId);

        if (existingPet == null)
            return new PrescriptionResponse("Invalid Pet");
        
        // Validate Title

        var existingPrescriptionWithTitle = await _prescriptionRepository.FindByTitleAsync(prescription.Title);

        if (existingPrescriptionWithTitle != null)
            return new PrescriptionResponse("Prescription title already exists.");

        try
        {
            // Add Prescription
            await _prescriptionRepository.AddAsync(prescription);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new PrescriptionResponse(prescription);

        }
        catch (Exception e)
        {
            // Error Handling
            return new PrescriptionResponse($"An error occurred while saving the prescription: {e.Message}");
        }

        
    }

    public async Task<PrescriptionResponse> UpdateAsync(int prescriptionId, Prescription prescription)
    {
        var existingPrescription = await _prescriptionRepository.FindByIdAsync(prescriptionId);
        
        // Validate Prescription

        if (existingPrescription == null)
            return new PrescriptionResponse("Prescription not found.");

        // Validate PetId

        var existingPet = await _petRepository.FindByIdAsync(prescription.PetId);

        if (existingPet == null)
            return new PrescriptionResponse("Invalid Pet");
        
        // Validate Title

        var existingPrescriptionWithTitle = await _prescriptionRepository.FindByTitleAsync(prescription.Title);

        if (existingPrescriptionWithTitle != null && existingPrescriptionWithTitle.Id != existingPrescription.Id)
            return new PrescriptionResponse("Prescription title already exists.");
        
        // Modify Fields
        existingPrescription.Title = prescription.Title;
        existingPrescription.Description = prescription.Description;
        existingPrescription.Published = prescription.Published;
        try
        {
            _prescriptionRepository.Update(existingPrescription);
            await _unitOfWork.CompleteAsync();

            return new PrescriptionResponse(existingPrescription);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new PrescriptionResponse($"An error occurred while updating the prescription: {e.Message}");
        }

    }

    public async Task<PrescriptionResponse> DeleteAsync(int prescriptionId)
    {
        var existingPrescription = await _prescriptionRepository.FindByIdAsync(prescriptionId);
        
        // Validate Prescription

        if (existingPrescription == null)
            return new PrescriptionResponse("Prescription not found.");
        
        try
        {
            _prescriptionRepository.Remove(existingPrescription);
            await _unitOfWork.CompleteAsync();

            return new PrescriptionResponse(existingPrescription);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new PrescriptionResponse($"An error occurred while deleting the prescription: {e.Message}");
        }

    }
}