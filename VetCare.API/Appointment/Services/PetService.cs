using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Repositories;
using VetCare.API.Appointment.Domain.Services;
using VetCare.API.Appointment.Domain.Services.Communication;

namespace VetCare.API.Appointment.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Pet>> ListAsync()
    {
        return await _petRepository.ListAsync();
    }

    public async Task<PetResponse> SaveAsync(Pet pet)
    {
        try
        {
            await _petRepository.AddAsync(pet);
            await _unitOfWork.CompleteAsync();
            return new PetResponse(pet);
        }
        catch (Exception e)
        {
            return new PetResponse($"An error occurred while saving the pet: {e.Message}");
        }
    }

    public async Task<PetResponse> UpdateAsync(int id, Pet pet)
    {
        var existingPet = await _petRepository.FindByIdAsync(id);

        if (existingPet == null)
            return new PetResponse("Category not found.");

        existingPet.Name = pet.Name;
        existingPet.Breed = pet.Breed;
        existingPet.Weight = pet.Weight;
        existingPet.Type = pet.Type;
        existingPet.photoUrl = pet.photoUrl;
        existingPet.Color = pet.Color;
        existingPet.Date = pet.Date;
        

        try
        {
            _petRepository.Update(existingPet);
            await _unitOfWork.CompleteAsync();

            return new PetResponse(existingPet);
        }
        catch (Exception e)
        {
            return new PetResponse($"An error occurred while updating the pet: {e.Message}");
        }
    }

    public async Task<PetResponse> DeleteAsync(int id)
    {
        var existingPet = await _petRepository.FindByIdAsync(id);

        if (existingPet == null)
            return new PetResponse("Pet not found.");

        try
        {
            _petRepository.Remove(existingPet);
            await _unitOfWork.CompleteAsync();

            return new PetResponse(existingPet);
        }
        catch (Exception e)
        {
            
            return new PetResponse($"An error occurred while deleting the pet: {e.Message}");
        }
    }
}