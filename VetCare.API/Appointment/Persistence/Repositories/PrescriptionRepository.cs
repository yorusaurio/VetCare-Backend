using Microsoft.EntityFrameworkCore;
using VetCare.API.Appointment.Domain.Models;
using VetCare.API.Appointment.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Shared.Persistence.Repositories;

namespace VetCare.API.Appointment.Persistence.Repositories;

public class PrescriptionRepository : BaseRepository, IPrescriptionRepository
{
    public PrescriptionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Prescription>> ListAsync()
    {
        return await _context.Prescriptions
            .Include(p => p.Pet)
            .ToListAsync();
    }

    public async Task AddAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
    }

    public async Task<Prescription> FindByIdAsync(int prescriptionId)
    {
        return await _context.Prescriptions
            .Include(p => p.Pet)
            .FirstOrDefaultAsync(p => p.Id == prescriptionId);
        
    }

    public async Task<Prescription> FindByTitleAsync(string title)
    {
        return await _context.Prescriptions
            .Include(p => p.Pet)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Prescription>> FindByPetIdAsync(int petId)
    {
        return await _context.Prescriptions
            .Where(p => p.PetId == petId)
            .Include(p => p.Pet)
            .ToListAsync();
    }

    public void Update(Prescription prescription)
    {
        _context.Prescriptions.Update(prescription);
    }

    public void Remove(Prescription prescription)
    {
        _context.Prescriptions.Remove(prescription);
    }
}