using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Store.Domain.Repositories;

namespace VetCare.API.Shared.Persistence.Repositories;

public class UnitOfWorkS : IUnitOfWorkS
{
    private readonly AppDbContext _context;

    public UnitOfWorkS(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}