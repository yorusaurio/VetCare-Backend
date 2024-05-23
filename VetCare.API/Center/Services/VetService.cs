using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Repositories;
using VetCare.API.Center.Domain.Services;
using VetCare.API.Center.Domain.Services.Communication;

namespace VetCare.API.Center.Services;

public class VetService : IVetService
{
    private readonly IVetRepository _vetRepository;
    private readonly IUnitOfWorkV _unitOfWorkV;

    public VetService(IVetRepository vetRepository, IUnitOfWorkV unitOfWorkV)
    {
        _vetRepository = vetRepository;
        _unitOfWorkV = unitOfWorkV;
    }

    public async Task<IEnumerable<Vet>> ListAsync()
    {
        return await _vetRepository.ListAsync();
    }

    public async Task<VetResponse> SaveAsync(Vet vet)
    {
        try
        {
            await _vetRepository.AddAsync(vet);
            await _unitOfWorkV.CompleteAsync();
            return new VetResponse(vet);
        }
        catch (Exception e)
        {
            return new VetResponse($"An error occurred while saving the vet: {e.Message}");
        }
    }

    public async Task<VetResponse> UpdateAsync(int id, Vet vet)
    {
        var existingVet = await _vetRepository.FindByIdAsync(id);

        if (existingVet == null)
            return new VetResponse("Vet not found.");

        


        existingVet.Firstname = vet.Firstname;
        existingVet.Lastname = vet.Lastname;
        existingVet.Email = vet.Email;
        existingVet.Gender = vet.Gender;
        existingVet.Birthdate = vet.Birthdate;
        existingVet.ImageUrl = vet.ImageUrl;
      
        

        try
        {
            _vetRepository.Update(existingVet);
            await _unitOfWorkV.CompleteAsync();

            return new VetResponse(existingVet);
        }
        catch (Exception e)
        {
            return new VetResponse($"An error occurred while updating the vet: {e.Message}");
        }
    }

    public async Task<VetResponse> DeleteAsync(int id)
    {
        var existingVet = await _vetRepository.FindByIdAsync(id);

        if (existingVet == null)
            return new VetResponse("Vet not found.");

        try
        {
            _vetRepository.Remove(existingVet);
            await _unitOfWorkV.CompleteAsync();

            return new VetResponse(existingVet);
        }
        catch (Exception e)
        {
            
            return new VetResponse($"An error occurred while deleting the vet: {e.Message}");
        }
    }
}