using Microsoft.EntityFrameworkCore;
using VetCare.API.Center.Domain.Models;
using VetCare.API.Center.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Shared.Persistence.Repositories;

namespace VetCare.API.Center.Persistence.Repositories;

public class VeterinaryRepository : BaseRepository, IVeterinaryRepository
{
    public VeterinaryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Veterinary>> ListAsync()
    {
        return await _context.Veterinary
            .Include(p => p.Vet)
            .ToListAsync();
    }

    public async Task AddAsync(Veterinary veterinary)
    {
        await _context.Veterinary.AddAsync(veterinary);
    }

    public async Task<Veterinary> FindByIdAsync(int veterinaryId)
    {
        return await _context.Veterinary
            .Include(p => p.Vet)
            .FirstOrDefaultAsync(p => p.Id == veterinaryId);
        
    }

    public async Task<Veterinary> FindByTitleAsync(string title)
    {
        return await _context.Veterinary
            .Include(p => p.Vet)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Veterinary>> FindByVetIdAsync(int vetId)
    {
        return await _context.Veterinary
            .Where(p => p.VetId == vetId)
            .Include(p => p.Vet)
            .ToListAsync();
    }

    public void Update(Veterinary veterinary)
    {
        _context.Veterinary.Update(veterinary);
    }

    public void Remove(Veterinary veterinary)
    {
        _context.Veterinary.Remove(veterinary);
    }
}