using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Repositories;
using VetCare.API.Center.Domain.Services;
using VetCare.API.Center.Domain.Services.Communication;

namespace VetCare.API.Center.Services;

public class VeterinaryService : IVeterinaryService
{
    private readonly IVeterinaryRepository _veterinaryRepository;
    private readonly IUnitOfWorkV _unitOfWorkV;
    private readonly IVetRepository _vetRepository;

    public VeterinaryService(IVeterinaryRepository veterinaryRepository, IUnitOfWorkV unitOfWorkV, IVetRepository vetRepository)
    {
        _veterinaryRepository = veterinaryRepository;
        _unitOfWorkV = unitOfWorkV;
        _vetRepository = vetRepository;
    }

    public async Task<IEnumerable<Veterinary>> ListAsync()
    {
        return await _veterinaryRepository.ListAsync();
    }

    public async Task<IEnumerable<Veterinary>> ListByVetIdAsync(int vetId)
    {
        return await _veterinaryRepository.FindByVetIdAsync(vetId);
    }

    public async Task<VeterinaryResponse> SaveAsync(Veterinary veterinary)
    {
        // Validate VetId

        var existingVet = await _vetRepository.FindByIdAsync(veterinary.VetId);

        if (existingVet == null)
            return new VeterinaryResponse("Invalid Vet");
        
        // Validate Title

        var existingVeterinaryWithTitle = await _veterinaryRepository.FindByTitleAsync(veterinary.Title);

        if (existingVeterinaryWithTitle != null)
            return new VeterinaryResponse("Veterinary title already exists.");

        try
        {
            // Add Veterinary
            await _veterinaryRepository.AddAsync(veterinary);
            
            // Complete Transaction
            await _unitOfWorkV.CompleteAsync();
            
            // Return response
            return new VeterinaryResponse(veterinary);

        }
        catch (Exception e)
        {
            // Error Handling
            return new VeterinaryResponse($"An error occurred while saving the veterinary: {e.Message}");
        }

        
    }

    public async Task<VeterinaryResponse> UpdateAsync(int veterinaryId, Veterinary veterinary)
    {
        var existingVeterinary = await _veterinaryRepository.FindByIdAsync(veterinaryId);
        
        // Validate Veterinary

        if (existingVeterinary == null)
            return new VeterinaryResponse("Veterinary not found.");

        // Validate VetId

        var existingVet = await _vetRepository.FindByIdAsync(veterinary.VetId);

        if (existingVet == null)
            return new VeterinaryResponse("Invalid Vet");
        
        // Validate Title

        var existingVeterinaryWithTitle = await _veterinaryRepository.FindByTitleAsync(veterinary.Title);

        if (existingVeterinaryWithTitle != null && existingVeterinaryWithTitle.Id != existingVeterinary.Id)
            return new VeterinaryResponse("Veterinary title already exists.");
        
        // Modify Fields
        existingVeterinary.Title = veterinary.Title;
        existingVeterinary.Description = veterinary.Description;
        existingVeterinary.Ranking = veterinary.Ranking;
        existingVeterinary.Address = veterinary.Address;
        existingVeterinary.phoneNumber = veterinary.phoneNumber;
        existingVeterinary.imageUrl = veterinary.imageUrl;
        
        
        try
        {
            _veterinaryRepository.Update(existingVeterinary);
            await _unitOfWorkV.CompleteAsync();

            return new VeterinaryResponse(existingVeterinary);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new VeterinaryResponse($"An error occurred while updating the veterinary: {e.Message}");
        }

    }

    public async Task<VeterinaryResponse> DeleteAsync(int veterinaryId)
    {
        var existingVeterinary = await _veterinaryRepository.FindByIdAsync(veterinaryId);
        
        // Validate Veterinary

        if (existingVeterinary == null)
            return new VeterinaryResponse("Veterinary not found.");
        
        try
        {
            _veterinaryRepository.Remove(existingVeterinary);
            await _unitOfWorkV.CompleteAsync();

            return new VeterinaryResponse(existingVeterinary);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new VeterinaryResponse($"An error occurred while deleting the veterinary: {e.Message}");
        }

    }
}