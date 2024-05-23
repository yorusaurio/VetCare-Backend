using Microsoft.EntityFrameworkCore;
using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Shared.Persistence.Repositories;

namespace VetCare.API.Appointment.Persistence.Repositories;

public class PetRepository : BaseRepository, IPetRepository
{
    public PetRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pet>> ListAsync()
    {
        return await _context.Pets.ToListAsync();
    }

    public async Task AddAsync(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
    }

    public async Task<Pet> FindByIdAsync(int id)
    {
        return await _context.Pets.FindAsync(id);
    }

    public void Update(Pet pet)
    {
        _context.Pets.Update(pet);
    }

    public void Remove(Pet pet)
    {
        _context.Pets.Remove(pet);
    }
}