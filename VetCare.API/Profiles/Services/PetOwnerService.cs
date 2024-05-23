using VetCare.API.Appointment.Domain.Repositories;
using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Profiles.Domain.Repositories;
using VetCare.API.Profiles.Domain.Services;
using VetCare.API.Profiles.Domain.Services.Communication;

namespace VetCare.API.Profiles.Services;

public class PetOwnerService : IPetOwnerService
{
    private readonly IPetOwnerRepository _petOwnerRepository;
    private readonly IUnitOfWorkP _unitOfWorkP;


    public PetOwnerService(IPetOwnerRepository petOwnerRepository, IUnitOfWorkP unitOfWorkP)
    {
        _petOwnerRepository = petOwnerRepository;
        _unitOfWorkP = unitOfWorkP;
    }

    public async Task<IEnumerable<PetOwner>> ListAsync()
    {
        return await _petOwnerRepository.ListAsync();
    }

    public async Task<PetOwnerResponse> SaveAsync(PetOwner petOwner)
    {
        try
        {
            await _petOwnerRepository.AddAsync(petOwner);
            await _unitOfWorkP.CompleteAsync();
            return new PetOwnerResponse(petOwner);
        }
        catch (Exception e)
        {
            return new PetOwnerResponse($"An error occurred while saving the vet: {e.Message}");
        }
    }

    public async Task<PetOwnerResponse> UpdateAsync(int id, PetOwner petOwner)
    {
        var existingPetOwner = await _petOwnerRepository.FindByIdAsync(id);

        if (existingPetOwner == null)
            return new PetOwnerResponse("Pet Owner not found.");
        
        existingPetOwner.Firstname = petOwner.Firstname;
        existingPetOwner.Lastname = petOwner.Lastname;
        existingPetOwner.Email = petOwner.Email;
        existingPetOwner.Gender = petOwner.Gender;
        existingPetOwner.Birthdate = petOwner.Birthdate;
        existingPetOwner.ImageUrl = petOwner.ImageUrl;
        
        try
        {
            _petOwnerRepository.Update(existingPetOwner);
            await _unitOfWorkP.CompleteAsync();

            return new PetOwnerResponse(existingPetOwner);
        }
        catch (Exception e)
        {
            return new PetOwnerResponse($"An error occurred while updating the vet: {e.Message}");
        }
    }

    public async Task<PetOwnerResponse> DeleteAsync(int id)
    {
        var existingPetOwner = await _petOwnerRepository.FindByIdAsync(id);
        
        if (existingPetOwner == null)
            return new PetOwnerResponse("Pet Owner not found.");
        
        try
        {
            _petOwnerRepository.Remove(existingPetOwner);
            await _unitOfWorkP.CompleteAsync();

            return new PetOwnerResponse(existingPetOwner);
        }
        catch (Exception e)
        {
            return new PetOwnerResponse($"An error occurred while updating the vet: {e.Message}");
        }
    }
}