using Microsoft.EntityFrameworkCore;
using VetCare.API.Profiles.Domain.Models;
using VetCare.API.Profiles.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Shared.Persistence.Repositories;

namespace VetCare.API.Profiles.Persistence.Repositories;

public class PetOwnerRepository : BaseRepository, IPetOwnerRepository
{
    public PetOwnerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PetOwner>> ListAsync()
    {
        return await _context.PetOwners.ToListAsync();
    }

    public async Task AddAsync(PetOwner petOwner)
    {
        await _context.PetOwners.AddAsync(petOwner);
    }

    public async Task<PetOwner> FindByIdAsync(int id)
    {
        return await _context.PetOwners.FindAsync(id);
    }

    public void Update(PetOwner petOwner)
    {
        _context.PetOwners.Update(petOwner);
    }

    public void Remove(PetOwner petOwner)
    {
        _context.PetOwners.Remove(petOwner);
    }
}