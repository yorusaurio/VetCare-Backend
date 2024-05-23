using VetCare.API.Center.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;

namespace VetCare.API.Shared.Persistence.Repositories;

public class UnitOfWorkV : IUnitOfWorkV
{
    private readonly AppDbContext _context;

    public UnitOfWorkV(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}